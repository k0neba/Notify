using System;
using System.Windows.Forms;
using Microsoft.Win32;  // Добавьте это пространство имен для работы с реестром

namespace Notify
{
    public partial class SettingsForm : Form
    {
        private MainForm mainForm;

        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadSettings();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ApplyLocalization();
        }

        public void ApplyLocalization()
        {
            this.Text = Localization.GetString("SettingsFormTitle");
            lblSelectedSound.Text = Localization.GetString("SoundFileLabel");
            chkAutoStart.Text = Localization.GetString("AutoStartCheckBox");
            btnSave.Text = Localization.GetString("SaveButton");
            btnCancel.Text = Localization.GetString("CancelButton");
            btnChangeLanguage.Text = Localization.GetString("ChangeLanguageButton");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mainForm.SoundFilePath = txtSoundFile.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkAutoStart.Checked;
            Properties.Settings.Default.AutoStart = isChecked;
            Properties.Settings.Default.Save();

            if (isChecked)
            {
                EnableAutoStart();
            }
            else
            {
                DisableAutoStart();
            }
        }

        private void EnableAutoStart()
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                registryKey.SetValue("NotifyApp", Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enabling auto start: " + ex.Message);
            }
        }

        private void DisableAutoStart()
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                registryKey.DeleteValue("NotifyApp", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling auto start: " + ex.Message);
            }
        }

        private void btnChangeLanguage_Click(object sender, EventArgs e)
        {
            string newLanguage = Localization.CurrentLanguage == "en" ? "uk" : "en";
            Localization.LoadLanguage(newLanguage);
            mainForm.ChangeLanguageFromSettings(newLanguage);
            ApplyLocalization();
        }

        private void BtnSelectSoundFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.wma|All Files|*.*";
                openFileDialog.Title = "Select a Sound File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    txtSoundFile.Text = selectedFilePath;
                    mainForm.SoundFilePath = selectedFilePath;
                    SaveSoundFilePath(selectedFilePath);
                    txtSoundFile.Text = selectedFilePath;
                }
            }
        }

        public void SaveSoundFilePath(string newSoundFilePath)
        {
            Properties.Settings.Default.SoundFilePath = newSoundFilePath;
            Properties.Settings.Default.Save();
        }

        private void LoadSettings()
        {
            if (mainForm.SoundFilePath != null)
            {
                txtSoundFile.Text = mainForm.SoundFilePath;
            }
            chkAutoStart.Checked = Properties.Settings.Default.AutoStart;
        }
    }
}
