using System;
using System.Windows.Forms;

namespace Notify
{
    public partial class CreateReminderForm : Form
    {
        private MainForm mainForm;

        public CreateReminderForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            ApplyLocalization();  // Применяем локализацию при инициализации формы
        }

        public void ApplyLocalization()
        {
            this.Text = Localization.GetString("CreateReminderFormTitle");
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

            DateTime selectedDate = dtpReminderDate.Value;
            DateTime reminderTime = new DateTime(
                selectedDate.Year,
                selectedDate.Month,
                selectedDate.Day,
                (int)nudReminderHour.Value,
                (int)nudReminderMinute.Value,
                0
            );

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

            mainForm.AddReminderToGrid(title, comment, link, reminderTime);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
