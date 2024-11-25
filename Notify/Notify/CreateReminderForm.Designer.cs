namespace Notify
{
    partial class CreateReminderForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtTitle;
        private TextBox txtLink;
        private TextBox txtComment;
        private DateTimePicker dtpReminderDate;
        private NumericUpDown nudReminderHour;
        private NumericUpDown nudReminderMinute;
        private Label lblTitle;
        private Label lblLink;
        private Label lblComment;
        private Label lblDate;
        private Label lblTime;

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
            txtTitle = new TextBox();
            txtLink = new TextBox();
            txtComment = new TextBox();
            dtpReminderDate = new DateTimePicker();
            nudReminderHour = new NumericUpDown();
            nudReminderMinute = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            lblLink = new Label();
            lblComment = new Label();
            lblDate = new Label();
            lblTime = new Label();
            ((System.ComponentModel.ISupportInitialize)nudReminderHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudReminderMinute).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 28);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(260, 23);
            txtTitle.TabIndex = 0;
            // 
            // txtLink
            // 
            txtLink.Location = new Point(12, 131);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(260, 23);
            txtLink.TabIndex = 1;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(12, 76);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(260, 23);
            txtComment.TabIndex = 2;
            // 
            // dtpReminderDate
            // 
            dtpReminderDate.Location = new Point(12, 175);
            dtpReminderDate.Name = "dtpReminderDate";
            dtpReminderDate.Size = new Size(120, 23);
            dtpReminderDate.TabIndex = 3;
            // 
            // nudReminderHour
            // 
            nudReminderHour.Location = new Point(166, 175);
            nudReminderHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            nudReminderHour.Name = "nudReminderHour";
            nudReminderHour.Size = new Size(50, 23);
            nudReminderHour.TabIndex = 4;
            // 
            // nudReminderMinute
            // 
            nudReminderMinute.Location = new Point(222, 175);
            nudReminderMinute.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudReminderMinute.Name = "nudReminderMinute";
            nudReminderMinute.Size = new Size(50, 23);
            nudReminderMinute.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(116, 212);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(197, 212);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(65, 15);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Заголовок";
            // 
            // lblLink
            // 
            lblLink.AutoSize = true;
            lblLink.Location = new Point(12, 113);
            lblLink.Name = "lblLink";
            lblLink.Size = new Size(69, 15);
            lblLink.TabIndex = 8;
            lblLink.Text = "Посилання";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new Point(12, 58);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(61, 15);
            lblComment.TabIndex = 9;
            lblComment.Text = "Коментар";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 157);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(32, 15);
            lblDate.TabIndex = 10;
            lblDate.Text = "Дата";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(166, 157);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(76, 15);
            lblTime.TabIndex = 11;
            lblTime.Text = "Час(год./хв.)";
            // 
            // CreateReminderForm
            // 
            ClientSize = new Size(287, 247);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblComment);
            Controls.Add(lblLink);
            Controls.Add(lblTitle);
            Controls.Add(nudReminderMinute);
            Controls.Add(nudReminderHour);
            Controls.Add(dtpReminderDate);
            Controls.Add(txtComment);
            Controls.Add(txtLink);
            Controls.Add(txtTitle);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "CreateReminderForm";
            Text = "Додавання нагадування";
            ((System.ComponentModel.ISupportInitialize)nudReminderHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudReminderMinute).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
