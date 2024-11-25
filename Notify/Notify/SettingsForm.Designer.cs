namespace Notify
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblSelectedSound;
        private System.Windows.Forms.TextBox txtSoundFile;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChangeLanguage;
        private System.Windows.Forms.Button BtnSelectSoundFile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSelectedSound = new Label();
            txtSoundFile = new TextBox();
            chkAutoStart = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnChangeLanguage = new Button();
            BtnSelectSoundFile = new Button();
            SuspendLayout();
            // 
            // lblSelectedSound
            // 
            lblSelectedSound.AutoSize = true;
            lblSelectedSound.Location = new Point(14, 18);
            lblSelectedSound.Margin = new Padding(4, 0, 4, 0);
            lblSelectedSound.Name = "lblSelectedSound";
            lblSelectedSound.Size = new Size(65, 15);
            lblSelectedSound.TabIndex = 0;
            lblSelectedSound.Text = "Sound File:";
            // 
            // txtSoundFile
            // 
            txtSoundFile.Location = new Point(142, 14);
            txtSoundFile.Margin = new Padding(4, 3, 4, 3);
            txtSoundFile.Name = "txtSoundFile";
            txtSoundFile.Size = new Size(224, 23);
            txtSoundFile.TabIndex = 1;
            // 
            // chkAutoStart
            // 
            chkAutoStart.AutoSize = true;
            chkAutoStart.Location = new Point(14, 45);
            chkAutoStart.Margin = new Padding(4, 3, 4, 3);
            chkAutoStart.Name = "chkAutoStart";
            chkAutoStart.Size = new Size(79, 19);
            chkAutoStart.TabIndex = 2;
            chkAutoStart.Text = "Auto Start";
            chkAutoStart.UseVisualStyleBackColor = true;
            chkAutoStart.CheckedChanged += chkAutoStart_CheckedChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(266, 70);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 27);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(361, 70);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 27);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnChangeLanguage
            // 
            btnChangeLanguage.Location = new Point(14, 70);
            btnChangeLanguage.Margin = new Padding(4, 3, 4, 3);
            btnChangeLanguage.Name = "btnChangeLanguage";
            btnChangeLanguage.Size = new Size(111, 27);
            btnChangeLanguage.TabIndex = 5;
            btnChangeLanguage.Text = "Change Language";
            btnChangeLanguage.UseVisualStyleBackColor = true;
            btnChangeLanguage.Click += btnChangeLanguage_Click;
            // 
            // BtnSelectSoundFile
            // 
            BtnSelectSoundFile.Location = new Point(374, 14);
            BtnSelectSoundFile.Name = "BtnSelectSoundFile";
            BtnSelectSoundFile.Size = new Size(75, 23);
            BtnSelectSoundFile.TabIndex = 6;
            BtnSelectSoundFile.Text = "Browse...";
            BtnSelectSoundFile.UseVisualStyleBackColor = true;
            BtnSelectSoundFile.Click += BtnSelectSoundFile_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 125);
            Controls.Add(BtnSelectSoundFile);
            Controls.Add(btnChangeLanguage);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkAutoStart);
            Controls.Add(txtSoundFile);
            Controls.Add(lblSelectedSound);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
