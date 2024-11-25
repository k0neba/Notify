using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Notify
{
    public partial class ReminderNotificationForm : Form
    {
        private MainForm mainForm;
        private Reminder _reminder;
        private string _currentLanguage;

        public ReminderNotificationForm(MainForm mainForm, Reminder reminder, string currentLanguage)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            _reminder = reminder;
            _currentLanguage = currentLanguage; // Сохраняем текущий язык
            this.Text = reminder.Title;

            ShowReminderDetails();
        }

        private void ShowReminderDetails()
        {
            lblTitle.Text = _reminder.Title;  // Отображаем заголовок напоминания
            lblComment.Text = _reminder.Comment;  // Отображаем комментарий напоминания

            // Если есть ссылка, показываем ее
            if (!string.IsNullOrEmpty(_reminder.Link))
            {
                lblLink.Text = _reminder.Link;
                lblLink.Visible = true;
                lblLink.Click += (sender, e) => OpenLink(_reminder.Link);  // Открыть ссылку по клику
            }
            else
            {
                lblLink.Visible = false;  // Если ссылки нет, скрываем элемент
            }
        }

        private void OpenLink(string url)
        {
            try
            {
                // Убираем лишние пробелы из URL
                url = url.Trim();

                // Проверяем, что URL не пустой
                if (!string.IsNullOrEmpty(url))
                {
                    // Открываем ссылку с использованием правильного формата
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true  // Открыть через системный браузер
                    });
                }
                else
                {
                    MessageBox.Show("Ссылка невалидна.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}");
            }
        }

        private void ReminderNotificationForm_Load(object sender, EventArgs e)
        {
            mainForm.PlaySound();
        }
    }
}
