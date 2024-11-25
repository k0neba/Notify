namespace Notify
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            dataGridView = new DataGridView();
            btnCreateReminder = new Button();
            btnEditReminder = new Button();
            btnDeleteReminder = new Button();
            btnSettings = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView.BackgroundColor = SystemColors.Menu;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(560, 169);
            dataGridView.TabIndex = 0;
            // 
            // btnCreateReminder
            // 
            btnCreateReminder.Location = new Point(12, 202);
            btnCreateReminder.Name = "btnCreateReminder";
            btnCreateReminder.Size = new Size(120, 23);
            btnCreateReminder.TabIndex = 1;
            btnCreateReminder.Text = "Create Reminder";
            btnCreateReminder.UseVisualStyleBackColor = true;
            btnCreateReminder.Click += btnCreateReminder_Click;
            // 
            // btnEditReminder
            // 
            btnEditReminder.Location = new Point(159, 202);
            btnEditReminder.Name = "btnEditReminder";
            btnEditReminder.Size = new Size(120, 23);
            btnEditReminder.TabIndex = 2;
            btnEditReminder.Text = "Edit Reminder";
            btnEditReminder.UseVisualStyleBackColor = true;
            btnEditReminder.Click += btnEditReminder_Click;
            // 
            // btnDeleteReminder
            // 
            btnDeleteReminder.Location = new Point(312, 202);
            btnDeleteReminder.Name = "btnDeleteReminder";
            btnDeleteReminder.Size = new Size(120, 23);
            btnDeleteReminder.TabIndex = 3;
            btnDeleteReminder.Text = "Delete Reminder";
            btnDeleteReminder.UseVisualStyleBackColor = true;
            btnDeleteReminder.Click += btnDeleteReminder_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(452, 202);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(120, 23);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(584, 274);
            Controls.Add(btnSettings);
            Controls.Add(btnDeleteReminder);
            Controls.Add(btnEditReminder);
            Controls.Add(btnCreateReminder);
            Controls.Add(dataGridView);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnCreateReminder;
        private System.Windows.Forms.Button btnEditReminder;
        private System.Windows.Forms.Button btnDeleteReminder;
        private System.Windows.Forms.Button btnSettings;
    }
}
