# Example Game Memory Trainer

## ⚠️ Read This

**WARNING:**  
This project is intended for **educational and research purposes only**.  
Do **not** use it to cheat in online/multiplayer games or violate any game's ToS (Terms of Service).  
**Use responsibly and ethically!**

---

## 🧑‍💻 Introduction

This repository demonstrates how to build a **game memory trainer** in C# (WinForms), focusing on real process memory editing in Windows.  
The example uses *Supermarket Simulator v1.0.2 (133)* as the demo target

---

## ✨ Features

- **Automatic game process detection**
- **Edit in-game Money, EXP, and Level** via a simple UI
- **Freeze Money:** lock the value so it never decreases
- Clean, readable, and well-commented code for easy learning
- Great starting point for anyone interested in game hacking, trainers, or the Windows API with C#

---

## 🚀 How to Use

1. **Clone this repository to your computer:**
    ```bash
    git clone https://github.com/nartodono/Example-Game-Memory-Trainer.git
    ```

2. **Open the project folder:**  
   (By default, it will be named `Example-Game-Memory-Trainer`.)

3. **Open `Trainer.sln` using Visual Studio.**

4. **Build and run the project:**  
   - Click the **Start** button or press `F5` in Visual Studio.

5. **Start _Supermarket Simulator v1.0.2 (133)_** on your PC.

6. **Use the trainer app:**  
   The trainer will automatically detect the running game and let you edit Money, EXP, Level, or freeze the money value in real time.

---

> **Please Note:**  
> - This trainer is designed and tested for *Supermarket Simulator v1.0.2 (133)*.  
> - It may **not** work for other versions of the game since those versions have not been tested yet.

---

## Learning Section

You can see all the code logic below
![Logic Code](Trainer/Form1.cs)
you can ignore all files other then this since those only used to make the program working properly.

### How it work?

This trainer basically only accessing another application process, read it memory and write/modify current memory.
The program firstly find the game process of Supermarket Simulator. the program always know if the game is open or no since it's always detect the process continously every one second
if the process is found, the program now find the memory address of money, exp and level by using the pointer chain.
once we get the memory address now we can read or even modify it's value.
The pointer chain to memory address where the game save value of money, exp and level is obtained through Cheat Engine, please refer to ![how to find the pointer chain](##how-to-find-the-pointer-chain) section about how to reproduce the step
The program is using pointer chain since the memory address is change dynamically everytime the game is opened

| ![unactive Trainer](docs/images/unactiveTrainer.png) | ![Active Trainer](docs/images/activeTrainer.png) |
|:--:|:--:|
| *Unactive Trainer* | *Active Trainer* |

## How to find the Pointer Chain
