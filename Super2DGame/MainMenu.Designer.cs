namespace Super2DGame
{
    partial class MainMenu
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
            StartGameButton = new Button();
            SettingsButton = new Button();
            SuspendLayout();
            // 
            // StartGameButton
            // 
            StartGameButton.Font = new Font("Segoe UI", 12F);
            StartGameButton.Location = new Point(181, 220);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(217, 41);
            StartGameButton.TabIndex = 0;
            StartGameButton.Text = "Начать игру";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Font = new Font("Segoe UI", 12F);
            SettingsButton.Location = new Point(181, 295);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(217, 41);
            SettingsButton.TabIndex = 1;
            SettingsButton.Text = "Настройки";
            SettingsButton.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 84, 74);
            ClientSize = new Size(584, 561);
            Controls.Add(SettingsButton);
            Controls.Add(StartGameButton);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainMenu";
            Text = "MainMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button StartGameButton;
        private Button SettingsButton;
    }
}