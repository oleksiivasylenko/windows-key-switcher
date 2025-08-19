using WinKeySwitcher.CustomButton;

namespace WinKeySwitcher
{
    partial class WinKeySwitcherForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnLeftKeySwitch = new PlayPauseButton();
            BtnRightKeySwitch = new PlayPauseButton();
            BtnBothKeySwitch = new PlayPauseButton();
            SuspendLayout();
            // 
            // BtnLeftKeySwitch
            // 
            BtnLeftKeySwitch.Location = new Point(20, 20);
            BtnLeftKeySwitch.Margin = new Padding(4, 5, 4, 5);
            BtnLeftKeySwitch.Name = "BtnLeftKeySwitch";
            BtnLeftKeySwitch.Size = new Size(200, 90);
            BtnLeftKeySwitch.TabIndex = 0;
            BtnLeftKeySwitch.UseVisualStyleBackColor = true;
            BtnLeftKeySwitch.Click += BtnLeftKeySwitchClick;

            // 
            // BtnBothKeySwitch
            // 
            BtnBothKeySwitch.Location = new Point(240, 20);
            BtnBothKeySwitch.Margin = new Padding(4, 5, 4, 5);
            BtnBothKeySwitch.Name = "BtnBothKeySwitch";
            BtnBothKeySwitch.Size = new Size(200, 90);
            BtnBothKeySwitch.TabIndex = 1;
            BtnBothKeySwitch.UseVisualStyleBackColor = true;
            BtnBothKeySwitch.Click += BtnBothKeySwitchClick;

            // 
            // BtnRightKeySwitch
            // 
            BtnRightKeySwitch.Location = new Point(460, 20);
            BtnRightKeySwitch.Margin = new Padding(4, 5, 4, 5);
            BtnRightKeySwitch.Name = "BtnRightKeySwitch";
            BtnRightKeySwitch.Size = new Size(200, 90);
            BtnRightKeySwitch.TabIndex = 2;
            BtnRightKeySwitch.UseVisualStyleBackColor = true;
            BtnRightKeySwitch.Click += BtnRightKeySwitchClick;

            // 
            // WinKeySwitchForm
            // 
            AutoScaleDimensions = new SizeF(15F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 130);
            Controls.Add(BtnBothKeySwitch);
            Controls.Add(BtnRightKeySwitch);
            Controls.Add(BtnLeftKeySwitch);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "WinKeySwitchForm";
            Text = "WIN-KEY SWITCHER";
            ResumeLayout(false);
        }


        #endregion

        private PlayPauseButton BtnLeftKeySwitch;
        private PlayPauseButton BtnRightKeySwitch;
        private PlayPauseButton BtnBothKeySwitch;
    }
}
