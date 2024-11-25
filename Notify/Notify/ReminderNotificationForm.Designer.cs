namespace Notify
{
    partial class ReminderNotificationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;    // Метка для заголовка
        private Label lblComment;  // Метка для комментария
        private Label lblLink;     // Метка для ссылки

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
            lblTitle = new Label();
            lblComment = new Label();
            lblLink = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(29, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new Point(12, 82);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(61, 15);
            lblComment.TabIndex = 1;
            lblComment.Text = "Comment";
            // 
            // lblLink
            // 
            lblLink.AutoSize = true;
            lblLink.ForeColor = Color.Blue;
            lblLink.Location = new Point(12, 157);
            lblLink.Name = "lblLink";
            lblLink.Size = new Size(29, 15);
            lblLink.TabIndex = 2;
            lblLink.Text = "Link";
            // 
            // ReminderNotificationForm
            // 
            ClientSize = new Size(486, 342);
            Controls.Add(lblTitle);
            Controls.Add(lblComment);
            Controls.Add(lblLink);
            Name = "ReminderNotificationForm";
            Text = "Reminder Notification";
            Load += ReminderNotificationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
