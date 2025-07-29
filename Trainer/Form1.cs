using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trainer
{
    public partial class Form1 : Form
    {
        #region Windows API Import
        // import function from kernel32.dll (Windows API) to get access
        // open access to another process in windows (OpenProcess)
        // read memory in another process (ReadProcessMemory)
        // write/modift memory in another process (WriteProcessMemory)
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesRead);
        #endregion

        #region Constants
        // permission used in hProc (we use only PROCESS_ALL_ACCESS) can modify to use one or two only
        //const int PROCESS_VM_READ = 0x0010; (Unused)
        //const int PROCESS_VM_WRITE = 0x0020; (Unused)
        //const int PROCESS_VM_OPERATION = 0x0008; (Unused)
        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        #endregion

        #region Global Memory & Game Variables
        // global variable for easier accessible variable
        Process game;
        IntPtr hProc = IntPtr.Zero;
        IntPtr moneyAddressGlobal = IntPtr.Zero;
        IntPtr expAddressGlobal = IntPtr.Zero;
        IntPtr levelAddressGlobal = IntPtr.Zero;

        // Flag for freeze money feature
        bool isMoneyFreeze = false;

        System.Windows.Forms.Timer funcTimer = new System.Windows.Forms.Timer();
        #endregion

        #region helper (read/write memory)
        // Pointer
        private IntPtr readPointer(IntPtr hProcess, IntPtr address, int offset)
        {
            byte[] buffer = new byte[8]; // 64-bit, jadi 8 byte
            ReadProcessMemory(hProcess, address, buffer, buffer.Length, out int bytesRead);

            IntPtr ptr = (IntPtr)BitConverter.ToInt64(buffer, 0);
            return IntPtr.Add(ptr, offset);
        }

        // read float value of a pointer
        private float readFloat(IntPtr hProcess, IntPtr address)
        {
            byte[] buffer = new byte[4]; // FLOAT = 4 byte
            ReadProcessMemory(hProcess, address, buffer, buffer.Length, out int bytesRead);
            return BitConverter.ToSingle(buffer, 0);
        }

        // write float value of a pointer
        private void writeFloat(IntPtr hProcess, IntPtr address, float value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            WriteProcessMemory(hProcess, address, buffer, buffer.Length, out int bytesWritten);
        }

        // read int value of a pointer
        private int readInt(IntPtr hProcess, IntPtr address)
        {
            byte[] buffer = new byte[4]; // INT = 4 byte
            ReadProcessMemory(hProcess, address, buffer, buffer.Length, out int bytesRead);
            return BitConverter.ToInt32(buffer, 0);
        }

        // write int value of a pointer
        private void writeInt(IntPtr hProcess, IntPtr address, int value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            WriteProcessMemory(hProcess, address, buffer, buffer.Length, out int bytesWritten);
        }
        #endregion

        #region Main Process
        // Main Code start from here ==========
        public Form1()
        {
            InitializeComponent();

            // only for styling
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //this.MinimizeBox = false;

            this.AutoScaleMode = AutoScaleMode.Dpi;
            //this.ClientSize = new Size(1020, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            statusLabel.Font = new Font(statusLabel.Font.FontFamily, 11);

            // start the auto check running program and/or pointer address
            // this allowing the trainer to keep updated about the game process and the game's memory
            funcTimer.Interval = 1000;
            funcTimer.Tick += funcTimer_Tick;
            funcTimer.Start();
        }

        // find game connection
        private Process gameConnect()
        {
            // find game process
            game = Process.GetProcessesByName("Supermarket Simulator").FirstOrDefault();
            if(game == null)
            {
                hProc = IntPtr.Zero;
                return null;
            }
            // if game found-> open handle with full permission to that process
            hProc = OpenProcess(PROCESS_ALL_ACCESS, false, game.Id);
            return game;
        }

        // timer
        private void funcTimer_Tick(object sender, EventArgs e)
        {
            // game not found
            if (gameConnect() == null)
            {
                // set off every button function and give information in the GUI
                statusLabel.Text = "Supermarket Simulator Process not detected!";
                statusLabel.ForeColor = Color.Red;

                moneyLabel.Text = "Money: Not Loaded";
                moneyLabel.ForeColor = Color.Red;
                moneyUpdateValue.Enabled = false;
                moneyUpdateBtn.Enabled = false;

                freezeMoneyBtn.Enabled = false;

                expLabel.Text = "EXP: Not Loaded";
                expLabel.ForeColor = Color.Red;
                expUpdateValue.Enabled = false;
                expUpdateBtn.Enabled = false;

                levelLabel.Text = "Level: Not Loaded";
                levelLabel.ForeColor = Color.Red;
                levelUpdateValue.Enabled = false;
                levelUpdateBtn.Enabled = false;

                freezeMoneyBtn.Checked = false;
                isMoneyFreeze = false;

                moneyAddressGlobal = IntPtr.Zero;
                expAddressGlobal = IntPtr.Zero;
                levelAddressGlobal = IntPtr.Zero;
                return;
            }

            // if game found
            // unlock all function in the GUI
            statusLabel.Text = $"Process found in {game} with PID: {game.Id}";
            statusLabel.ForeColor = Color.Green;

            levelLabel.ForeColor = Color.White;
            levelUpdateValue.Enabled = true;
            levelUpdateBtn.Enabled = true;

            expLabel.ForeColor = Color.White;
            expUpdateValue.Enabled = true;
            expUpdateBtn.Enabled = true;

            // if money freeze is active, disable money changer (optional, only for better UX)
            if (!isMoneyFreeze)
            {
                moneyLabel.ForeColor = Color.White;
                moneyUpdateBtn.Enabled = true;
                moneyUpdateValue.Enabled = true;
            }
            freezeMoneyBtn.Enabled = true;

            // find all necessary address
            getMoneyAddress(hProc);
            getExpAddress(hProc);
            getLevelAddress(hProc);

            // show all the value from the address
            showMoneyValue();
            showExpValue();
            showLevelValue();
        }
        #endregion

        // Money Related Function
        #region Money Modification
        // Find money address
        private void getMoneyAddress(IntPtr hProc)
        {
            // set base address
            IntPtr baseAddress = IntPtr.Zero;
            foreach (ProcessModule module in game.Modules)
            {
                if (module.ModuleName.ToLower() == "mono-2.0-bdwgc.dll")
                {
                    baseAddress = module.BaseAddress;
                    break;
                }
            }

            if (baseAddress == IntPtr.Zero) return;

            // pointer chain to Money address (the money pointer offset is 43C, 68, 0, 30, A0)
            IntPtr moneyAddr = IntPtr.Add(baseAddress, 0x00A14118);
            moneyAddr = readPointer(hProc, moneyAddr, 0x43C);
            moneyAddr = readPointer(hProc, moneyAddr, 0x68);
            moneyAddr = readPointer(hProc, moneyAddr, 0x0);
            moneyAddr = readPointer(hProc, moneyAddr, 0x30);
            moneyAddr = readPointer(hProc, moneyAddr, 0xA0);

            // save money address globally
            moneyAddressGlobal = moneyAddr;
        }

        // display the money to GUI
        private void showMoneyValue()
        {
            // if money global address is empty. find the address manually
            if(moneyAddressGlobal == IntPtr.Zero)
            {
                getMoneyAddress(hProc);
            }
            float currentMoney = readFloat(hProc, moneyAddressGlobal);
            moneyLabel.Text = $"Current money: {currentMoney}";
        }

        // action when the button of money is clicked
        private void moneyUpdateBtn_Click(object sender, EventArgs e)
        {
            // parse the value inside the input (textBox)
            if (float.TryParse(moneyUpdateValue.Text, out float newMoney))
            {
                // if money global address is empty. find the address manually
                if (moneyAddressGlobal == IntPtr.Zero)
                {
                    getMoneyAddress(hProc);
                }
                // write the value
                writeFloat(hProc, moneyAddressGlobal, newMoney);
                moneyUpdateValue.Text = "";

                // update the UI and send feedback
                showMoneyValue();
                MessageBox.Show($"Money updated to {newMoney}");
            }
            else
            {
                MessageBox.Show("Money update failed");
            }
        }

        // freeze money cancellationtoken
        private CancellationTokenSource freezeMoneyCts;

        // freeze money function
        private async void freezeMoneyBtn_CheckedChanged(object sender, EventArgs e)
        {
            // disable the checkbox to prevent spamming click, possibly leading to bugs
            freezeMoneyBtn.Enabled = false;

            // if the checkbox is checked
            if (freezeMoneyBtn.Checked)
            {
                // Create a new cancellation token for controlling the freeze loop
                freezeMoneyCts = new CancellationTokenSource();
                CancellationToken token = freezeMoneyCts.Token;

                // Set freeze flag to active and disable manual money editing in UI
                isMoneyFreeze = true;
                moneyUpdateValue.Enabled = false;
                moneyUpdateBtn.Enabled = false;

                // Read the current money value from game memory (to keep it frozen at this value)
                float currentMoney = readFloat(hProc, moneyAddressGlobal);

                // Start a background task that will keep setting the money value repeatedly
                _ = Task.Run(async () =>
                {
                    try
                    {
                        // When the loop starts, token.IsCancellationRequested is false
                        while (!token.IsCancellationRequested)
                        {
                            // Handle the case if the game is closed while freeze is active
                            if (game == null || game.HasExited)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    // Disable freeze flag and uncheck the checkbox in UI
                                    freezeMoneyBtn.Checked = false;
                                    isMoneyFreeze = false;

                                    // Cancel and clean up the cancellation token
                                    if (freezeMoneyCts != null)
                                    {
                                        freezeMoneyCts.Cancel();
                                        freezeMoneyCts.Dispose();
                                        freezeMoneyCts = null;
                                        token = default;
                                    }
                                }));
                                break;
                            }

                            // Continuously write the same money value to memory every 500ms to keep it frozen
                            writeFloat(hProc, moneyAddressGlobal, currentMoney);
                            await Task.Delay(500, token);
                        }
                    }
                    catch (TaskCanceledException)
                    {

                    }
                });
            }
            // if the checkbox is unchecked
            else
            {
                // Cancel and clean up the cancellation token
                if (freezeMoneyCts != null)
                {
                    freezeMoneyCts.Cancel();
                    freezeMoneyCts.Dispose();
                    freezeMoneyCts = null;
                }

                // Disable freeze flag and uncheck the checkbox in UI
                isMoneyFreeze = false;
                moneyUpdateValue.Enabled = true;
                moneyUpdateBtn.Enabled = true;
            }

            // after 500ms the checkbox can function normally again
            await Task.Delay(500);
            freezeMoneyBtn.Enabled = true;
        }
        #endregion

        // EXP Related Function
        #region EXP Modification

        // get exp address
        private void getExpAddress(IntPtr hProc)
        {
            // find the base address
            IntPtr baseAddress = IntPtr.Zero;
            foreach (ProcessModule module in game.Modules)
            {
                if (module.ModuleName.ToLower() == "mono-2.0-bdwgc.dll")
                {
                    baseAddress = module.BaseAddress;
                    break;
                }
            }

            if (baseAddress == IntPtr.Zero) return;

            // pointer chain to EXP address (the exp pointer offset is 43C, 68, 0, 30, C4)
            IntPtr expAddr = IntPtr.Add(baseAddress, 0x00A14118);
            expAddr = readPointer(hProc, expAddr, 0x43C); 
            expAddr = readPointer(hProc, expAddr, 0x68);
            expAddr = readPointer(hProc, expAddr, 0x0);
            expAddr = readPointer(hProc, expAddr, 0x30);
            expAddr = readPointer(hProc, expAddr, 0xC4);

            // save exp address globally
            expAddressGlobal = expAddr;
        }

        // display current exp 
        private void showExpValue()
        {
            // if global exp address is empty, find the adress manually
            if(expAddressGlobal == IntPtr.Zero)
            {
                getExpAddress(hProc);
            }
            int currentExp = readInt(hProc, expAddressGlobal);
            expLabel.Text = $"Current exp: {currentExp}";
        }

        // change current exp
        private void expUpdateBtn_Click(object sender, EventArgs e)
        {
            // parse the inputted exp value
            if(int.TryParse(expUpdateValue.Text, out int newExp))
            {
                // if global exp address is empty, find the address manually
                if (expAddressGlobal == IntPtr.Zero)
                {
                    getExpAddress(hProc);
                }
                // update the exp value 
                writeInt(hProc, expAddressGlobal, newExp);
                expUpdateValue.Text = "";

                // update display exp value in UI and give feedback
                showExpValue();
                MessageBox.Show($"EXP updated to {newExp}");
            }
            else
            {
                MessageBox.Show("Update EXP Failed");
            }
        }
        #endregion

        // Level Related Function
        #region Level Modification
        
        // find level address
        private void getLevelAddress(IntPtr hProc)
        {
            IntPtr baseAddress = IntPtr.Zero;
            foreach(ProcessModule module in game.Modules)
            {
                // find the base address
                if (module.ModuleName.ToLower() == "mono-2.0-bdwgc.dll")
                {
                    baseAddress = module.BaseAddress;
                    break;
                }
            }

            if (baseAddress == IntPtr.Zero) return;

            // pointer chain to Level address (the level pointer offset is 43C, 68, 0, 30, C8)
            IntPtr levelAddr = IntPtr.Add(baseAddress, 0x00A14118);
            levelAddr = readPointer(hProc, levelAddr, 0x43C);
            levelAddr = readPointer(hProc, levelAddr, 0x68);
            levelAddr = readPointer(hProc, levelAddr, 0x0);
            levelAddr = readPointer(hProc, levelAddr, 0x30);
            levelAddr = readPointer(hProc, levelAddr, 0xC8);

            // update level address globally
            levelAddressGlobal = levelAddr;
        }

        // display current level
        private void showLevelValue()
        {
            // if global level address is empty, find the adress manually
            if (levelAddressGlobal == IntPtr.Zero)
            {
                getLevelAddress(hProc);
            }
            int currentLevel = readInt(hProc, levelAddressGlobal);
            levelLabel.Text = $"Current level: {currentLevel}";
        }

        // modify current level
        private void levelUpdateBtn_Click(object sender, EventArgs e)
        {
            // parse level user input
            if(int.TryParse(levelUpdateValue.Text, out int newLevel))
            {
                // if global level address is empty, find the adress manually
                if (levelAddressGlobal == IntPtr.Zero)
                {
                    getLevelAddress(hProc);
                }
                // write new level to memory
                writeInt(hProc, levelAddressGlobal, newLevel);
                levelUpdateValue.Text = "";

                // update trainer UI and send feedback
                showLevelValue();
                MessageBox.Show($"Level updated to {newLevel}");
            }
            else
            {
                MessageBox.Show("Update Level Failed");
            }
        }
        #endregion

        // End
    }
}