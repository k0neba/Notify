using System;
using System.Windows.Forms;

namespace Notify
{
    public partial class EditReminderForm : Form
    {
        private int rowIndex;
        private MainForm mainForm;

        // Убедитесь, что DateTimePicker добавлен на форму в дизайнере.
        private DateTimePicker dtpReminderDate;

        public EditReminderForm(int rowIndex, Reminder reminder, MainForm mainForm)
        {
            InitializeComponent();

            this.rowIndex = rowIndex;
            this.mainForm = mainForm;

            // Проверяем, что компоненты были инициализированы
            if (dtpReminderDate != null)
            {
                // Заполняем поля формы данными из reminder
                txtTitle.Text = reminder.Title;
                txtComment.Text = reminder.Comment;
                txtLink.Text = reminder.Link;

                // Устанавливаем дату и время
                dtpReminderDate.Value = reminder.ReminderTime;  // Устанавливаем дату и время из Reminder
                nudReminderHour.Value = reminder.ReminderTime.Hour;  // Часы
                nudReminderMinute.Value = reminder.ReminderTime.Minute;  // Минуты
            }
            else
            {
                MessageBox.Show("Ошибка: Элемент DateTimePicker не был инициализирован.");
            }

            // Применяем локализацию
            ApplyLocalization();
        }

        public void ApplyLocalization()
        {
            // Применение локализации
            this.Text = Localization.GetString("EditReminderFormTitle");
            btnSave.Text = Localization.GetString("Save");
            btnCancel.Text = Localization.GetString("Cancel");
            lblTitle.Text = Localization.GetString("TitleLabel");
            lblComment.Text = Localization.GetString("CommentLabel");
            lblLink.Text = Localization.GetString("LinkLabel");
            lblDate.Text = Localization.GetString("DateLabel");
            lblTime.Text = Localization.GetString("Time");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string link = txtLink.Text;
            string comment = txtComment.Text;

            DateTime reminderTime = dtpReminderDate.Value.Date.AddHours((double)nudReminderHour.Value)
                                                                .AddMinutes((double)nudReminderMinute.Value);

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Потрібно створити ЗАГОЛОВОК", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (reminderTime == default)
            {
                MessageBox.Show("Потрібно обрати ЧАС!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainForm.UpdateReminderInGrid(rowIndex, title, comment, link, reminderTime);
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Закрытие формы без сохранения изменений
            this.Close();
        }
    }
}
