using System.Drawing;

namespace Trainer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.freezeMoneyBtn = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.moneyUpdateValue = new System.Windows.Forms.TextBox();
            this.moneyUpdateBtn = new System.Windows.Forms.Button();
            this.levelLabel = new System.Windows.Forms.Label();
            this.expLabel = new System.Windows.Forms.Label();
            this.levelUpdateValue = new System.Windows.Forms.TextBox();
            this.expUpdateValue = new System.Windows.Forms.TextBox();
            this.levelUpdateBtn = new System.Windows.Forms.Button();
            this.expUpdateBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.groupBoxStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Indigo;
            this.headerPanel.Controls.Add(this.label7);
            this.headerPanel.Controls.Add(this.labelTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1018, 74);
            this.headerPanel.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(254, 19);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(513, 46);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Supermarket Simulator Trainer";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.statusLabel.ForeColor = System.Drawing.Color.Lime;
            this.statusLabel.Location = new System.Drawing.Point(12, 90);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(153, 28);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "STATUS: NONE";
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.groupBoxStats.Controls.Add(this.freezeMoneyBtn);
            this.groupBoxStats.Controls.Add(this.label6);
            this.groupBoxStats.Controls.Add(this.label4);
            this.groupBoxStats.Controls.Add(this.label3);
            this.groupBoxStats.Controls.Add(this.label5);
            this.groupBoxStats.Controls.Add(this.label2);
            this.groupBoxStats.Controls.Add(this.label1);
            this.groupBoxStats.Controls.Add(this.moneyLabel);
            this.groupBoxStats.Controls.Add(this.moneyUpdateValue);
            this.groupBoxStats.Controls.Add(this.moneyUpdateBtn);
            this.groupBoxStats.Controls.Add(this.levelLabel);
            this.groupBoxStats.Controls.Add(this.expLabel);
            this.groupBoxStats.Controls.Add(this.levelUpdateValue);
            this.groupBoxStats.Controls.Add(this.expUpdateValue);
            this.groupBoxStats.Controls.Add(this.levelUpdateBtn);
            this.groupBoxStats.Controls.Add(this.expUpdateBtn);
            this.groupBoxStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxStats.ForeColor = System.Drawing.Color.White;
            this.groupBoxStats.Location = new System.Drawing.Point(17, 135);
            this.groupBoxStats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxStats.Size = new System.Drawing.Size(831, 337);
            this.groupBoxStats.TabIndex = 0;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Cheat List";
            // 
            // freezeMoneyBtn
            // 
            this.freezeMoneyBtn.AutoSize = true;
            this.freezeMoneyBtn.Location = new System.Drawing.Point(638, 51);
            this.freezeMoneyBtn.Name = "freezeMoneyBtn";
            this.freezeMoneyBtn.Size = new System.Drawing.Size(166, 32);
            this.freezeMoneyBtn.TabIndex = 9;
            this.freezeMoneyBtn.Text = "Freeze Money";
            this.freezeMoneyBtn.UseVisualStyleBackColor = true;
            this.freezeMoneyBtn.CheckedChanged += new System.EventHandler(this.freezeMoneyBtn_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(269, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Modify current level into your input";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(269, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Modify current EXP into your input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(269, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Modify current money into your input";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.MediumOrchid;
            this.label5.Location = new System.Drawing.Point(16, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(16, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "EXP (Not Level)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Money";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.moneyLabel.ForeColor = System.Drawing.Color.White;
            this.moneyLabel.Location = new System.Drawing.Point(16, 69);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(180, 28);
            this.moneyLabel.TabIndex = 0;
            this.moneyLabel.Text = "Money Placeholder";
            // 
            // moneyUpdateValue
            // 
            this.moneyUpdateValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.moneyUpdateValue.Location = new System.Drawing.Point(271, 49);
            this.moneyUpdateValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.moneyUpdateValue.Name = "moneyUpdateValue";
            this.moneyUpdateValue.Size = new System.Drawing.Size(200, 34);
            this.moneyUpdateValue.TabIndex = 1;
            // 
            // moneyUpdateBtn
            // 
            this.moneyUpdateBtn.AutoSize = true;
            this.moneyUpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moneyUpdateBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.moneyUpdateBtn.Location = new System.Drawing.Point(477, 49);
            this.moneyUpdateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.moneyUpdateBtn.Name = "moneyUpdateBtn";
            this.moneyUpdateBtn.Size = new System.Drawing.Size(74, 35);
            this.moneyUpdateBtn.TabIndex = 2;
            this.moneyUpdateBtn.Text = "Modify";
            this.moneyUpdateBtn.Click += new System.EventHandler(this.moneyUpdateBtn_Click);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.levelLabel.ForeColor = System.Drawing.Color.White;
            this.levelLabel.Location = new System.Drawing.Point(16, 291);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(163, 28);
            this.levelLabel.TabIndex = 3;
            this.levelLabel.Text = "Level Placeholder";
            // 
            // expLabel
            // 
            this.expLabel.AutoSize = true;
            this.expLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.expLabel.ForeColor = System.Drawing.Color.White;
            this.expLabel.Location = new System.Drawing.Point(16, 182);
            this.expLabel.Name = "expLabel";
            this.expLabel.Size = new System.Drawing.Size(152, 28);
            this.expLabel.TabIndex = 3;
            this.expLabel.Text = "EXP Placeholder";
            // 
            // levelUpdateValue
            // 
            this.levelUpdateValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.levelUpdateValue.Location = new System.Drawing.Point(271, 262);
            this.levelUpdateValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.levelUpdateValue.Name = "levelUpdateValue";
            this.levelUpdateValue.Size = new System.Drawing.Size(200, 34);
            this.levelUpdateValue.TabIndex = 4;
            // 
            // expUpdateValue
            // 
            this.expUpdateValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.expUpdateValue.Location = new System.Drawing.Point(271, 155);
            this.expUpdateValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.expUpdateValue.Name = "expUpdateValue";
            this.expUpdateValue.Size = new System.Drawing.Size(200, 34);
            this.expUpdateValue.TabIndex = 4;
            // 
            // levelUpdateBtn
            // 
            this.levelUpdateBtn.AutoSize = true;
            this.levelUpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.levelUpdateBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.levelUpdateBtn.Location = new System.Drawing.Point(477, 262);
            this.levelUpdateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.levelUpdateBtn.Name = "levelUpdateBtn";
            this.levelUpdateBtn.Size = new System.Drawing.Size(74, 35);
            this.levelUpdateBtn.TabIndex = 5;
            this.levelUpdateBtn.Text = "Modify";
            this.levelUpdateBtn.Click += new System.EventHandler(this.levelUpdateBtn_Click);
            // 
            // expUpdateBtn
            // 
            this.expUpdateBtn.AutoSize = true;
            this.expUpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expUpdateBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.expUpdateBtn.Location = new System.Drawing.Point(477, 155);
            this.expUpdateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.expUpdateBtn.Name = "expUpdateBtn";
            this.expUpdateBtn.Size = new System.Drawing.Size(74, 35);
            this.expUpdateBtn.TabIndex = 5;
            this.expUpdateBtn.Text = "Modify";
            this.expUpdateBtn.Click += new System.EventHandler(this.expUpdateBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(3, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "For Game V1.0.2(133)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1018, 592);
            this.Controls.Add(this.groupBoxStats);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trainer Test 1";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion


        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.TextBox moneyUpdateValue;
        private System.Windows.Forms.Button moneyUpdateBtn;
        private System.Windows.Forms.Label expLabel;
        private System.Windows.Forms.TextBox expUpdateValue;
        private System.Windows.Forms.Button expUpdateBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.TextBox levelUpdateValue;
        private System.Windows.Forms.Button levelUpdateBtn;
        private System.Windows.Forms.CheckBox freezeMoneyBtn;
        private System.Windows.Forms.Label label7;
    }
}

