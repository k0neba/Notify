using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Windows.Forms;
using Notify;
using NAudio.Wave;
namespace Notify
{
    public partial class MainForm : Form
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip trayMenu;
        public BindingList<Reminder> Reminders { get; set; }
        public string CurrentLanguage { get; private set; }
        private System.Windows.Forms.Timer reminderTimer;
        public string SoundFilePath { get; set; }
        private string reminderFilePath;
        public MainForm()
        {
            this.FormClosing += OnFormClosing;
            InitializeComponent();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            reminderFilePath = Path.Combine(appDataPath, "reminders.xml");

            (Reminders, CurrentLanguage) = ReminderStorage.LoadReminders(reminderFilePath);
            Localization.LoadLanguage(CurrentLanguage);
            ApplyLocalization();
            InitializeDataGridView();
            dataGridView.DataSource = Reminders;

            reminderTimer = new System.Windows.Forms.Timer();
            reminderTimer.Interval = 1000;
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();

            // Создание NotifyIcon и его настройка
            InitializeTrayIcon();  // Инициализируем иконку в системном трее
        }

        private void InitializeTrayIcon()
        {
            if (notifyIcon != null)
            {
                notifyIcon.Dispose();  // Если иконка уже существует, удаляем её
            }

            notifyIcon = new NotifyIcon();
            notifyIcon.Text = "Reminder Application";
            notifyIcon.Icon = new Icon(SystemIcons.Information, 40, 40);  // Или ваша иконка
            notifyIcon.Visible = true;  // Убедитесь, что иконка видна

            // Создаем контекстное меню
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Open", null, (s, e) => ShowMainForm());
            trayMenu.Items.Add("Exit", null, (s, e) => ExitApplication());

            // Назначаем контекстное меню иконке
            notifyIcon.ContextMenuStrip = trayMenu;

            // Подписка на событие клика по иконке
            notifyIcon.DoubleClick += (s, e) => ShowMainForm();
        }

        private void ShowMainForm()
        {
            this.Show();  // Показываем главную форму
            this.WindowState = FormWindowState.Normal;  // Восстанавливаем форму в нормальный режим
            this.Activate();  // Делаем форму активной
            this.ShowInTaskbar = true;  // Показываем иконку в панели задач
        }
        private void ExitApplication()
        {
            Application.Exit();  // Закрывает приложение
        }
        private void PlayMp3Sound(string soundFilePath)
        {
            try
            {
                using (var reader = new Mp3FileReader(soundFilePath))  // Чтение MP3 файла
                using (var outputDevice = new WaveOutEvent())  // Создание устройства для воспроизведения
                {
                    outputDevice.Init(reader);  // Инициализация устройства воспроизведения
                    outputDevice.Play();  // Воспроизведение звука
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);  // Ошибка воспроизведения
            }
        }

        // Метод для добавления напоминания в DataGridView
        public void AddReminderToGrid(string title, string comment, string link, DateTime reminderTime)
        {
            var reminder = new Reminder
            {
                Title = title,
                Comment = comment,
                Link = link,
                ReminderTime = reminderTime,
                IsShown = false,
                PlaySound = false,
                SoundFile = string.Empty
            };
            Reminders.Add(reminder);
            ReminderStorage.SaveReminders(Reminders.ToList(), CurrentLanguage, reminderFilePath);
            dataGridView.Refresh();
        }


        public void UpdateReminderInGrid(int index, string title, string comment, string link, DateTime reminderTime)
        {
            if (index >= 0 && index < Reminders.Count)
            {
                var reminder = Reminders[index];
                reminder.Title = title;
                reminder.Comment = comment;
                reminder.Link = link;
                reminder.ReminderTime = reminderTime;
                ReminderStorage.SaveReminders(Reminders.ToList(), CurrentLanguage, reminderFilePath);
                dataGridView.Refresh();
            }
        }
        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            foreach (var reminder in Reminders)
            {
                if (reminder.ReminderTime <= currentTime && !reminder.IsShown)
                {
                    ShowReminder(reminder);
                    reminder.IsShown = true;
                }
            }

            // Сохраняем обновления в файл
            ReminderStorage.SaveReminders(Reminders.ToList(), CurrentLanguage, reminderFilePath);
        }

        private void ShowReminder(Reminder reminder)
        {
            // Проверка на пустой путь звукового файла
            if (string.IsNullOrEmpty(reminder.SoundFile))
            {
                reminder.SoundFile = "default.wav";  // Устанавливаем путь к звуку по умолчанию, если его нет
            }

            // Показываем уведомление в трее
            if (this.IsDisposed) return;  // Если форма закрыта или уничтожена, не показываем уведомление

            try
            {
                // Показываем уведомление в трее
                notifyIcon.BalloonTipTitle = "Напоминание";
                notifyIcon.BalloonTipText = $"Время для напоминания: {reminder.Title}";
                notifyIcon.ShowBalloonTip(5000);  // Показываем уведомление на 5 секунд

                // Воспроизводим звук, если он задан
                PlayReminderSound(reminder.SoundFile);

                // Открытие формы напоминания, если нужно
                ReminderNotificationForm reminderForm = new ReminderNotificationForm(this, reminder, CurrentLanguage);
                reminderForm.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при показе напоминания: " + ex.Message);
            }
        }


        public void PlaySound()
        {
            if (!string.IsNullOrEmpty(SoundFilePath) && System.IO.File.Exists(SoundFilePath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(SoundFilePath);
                    player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error playing sound: " + ex.Message);
                }
            }
        }
        // Метод для воспроизведения звука напоминания
        private void PlayReminderSound(string soundFilePath)
        {
            try
            {
                if (string.IsNullOrEmpty(soundFilePath))
                {
                    // Используем дефолтный звук, если путь пустой
                    soundFilePath = "default.wav";  // Путь к звуку по умолчанию
                }

                // Проверяем, существует ли файл по указанному пути
                if (File.Exists(soundFilePath))
                {
                    if (soundFilePath.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
                    {
                        // Воспроизводим MP3 файл с помощью NAudio
                        PlayMp3Sound(soundFilePath);
                    }
                    else
                    {
                        // Воспроизводим WAV файл с помощью SoundPlayer
                        SoundPlayer player = new SoundPlayer(soundFilePath);
                        player.Play();
                    }
                }
                else
                {
                    // Если файл не существует, выводим ошибку
                    MessageBox.Show("Звуковой файл не найден: " + soundFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);
            }
        }


        public void ApplyLocalization()
        {
            this.Text = Localization.GetString("MainFormTitle");
            btnCreateReminder.Text = Localization.GetString("CreateReminderButton");
            btnEditReminder.Text = Localization.GetString("EditReminderButton");
            btnDeleteReminder.Text = Localization.GetString("DeleteReminderButton");
            btnSettings.Text = Localization.GetString("SettingsButton");  // Обновляем текст кнопки настроек
        }

        public interface ILocalizable
        {
            void ApplyLocalization();
        }

        public void ChangeLanguageFromSettings(string newLanguage)
        {
            // Меняем язык и обновляем форму
            CurrentLanguage = newLanguage;
            Localization.LoadLanguage(newLanguage);  // Загружаем локализацию для выбранного языка
            ApplyLocalization();  // Применяем локализацию на MainForm, обновляя все элементы интерфейса

            // Сохраняем выбранный язык в настройки
            Properties.Settings.Default.Language = newLanguage;
            Properties.Settings.Default.Save();  // Сохраняем изменения в настрой
        }

        private void btnCreateReminder_Click(object sender, EventArgs e)
        {
            CreateReminderForm createReminderForm = new CreateReminderForm(this);
            createReminderForm.ShowDialog(); // Открываем форму как диалоговое окно
        }

        private void btnEditReminder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView.SelectedRows[0].Index;
                Reminder selectedReminder = (Reminder)dataGridView.SelectedRows[0].DataBoundItem;
                EditReminderForm editReminderForm = new EditReminderForm(rowIndex, selectedReminder, this);
                editReminderForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите напоминание для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteReminder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                Reminder selectedReminder = (Reminder)dataGridView.SelectedRows[0].DataBoundItem;
                Reminders.Remove(selectedReminder);
                ReminderStorage.SaveReminders(Reminders.ToList(), CurrentLanguage, reminderFilePath); // Преобразуем BindingList в List и добавляем путь
            }
        }

        private void InitializeDataGridView()
        {
            // Устанавливаем авто-генерацию столбцов
            dataGridView.AutoGenerateColumns = false;

            // Устанавливаем столбцы для DataGridView
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = Localization.GetString("TitleLabel")
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Comment",
                HeaderText = Localization.GetString("CommentLabel")
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Link",
                HeaderText = Localization.GetString("LinkLabel")
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReminderTime",
                HeaderText = Localization.GetString("DateLabel")
            });


            // Устанавливаем нумерацию в заголовках строк
            dataGridView.RowHeadersWidth = 50;  // Устанавливаем ширину столбца для индексов
            dataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowHeadersVisible = true;
        }
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Добавляем нумерацию строк (индексы)
            using (var brush = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                string rowIndex = (e.RowIndex + 1).ToString();  // Индексация начинается с 1
                e.Graphics.DrawString(rowIndex, dataGridView.Font, brush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();
            SaveSettings(); // Сохраним настройки после закрытия формы настроек
        }

        // Переопределение OnFormClosing для остановки таймера при закрытии формы
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;  // Отменяем закрытие формы
                this.Hide();  // Скрываем форму
                this.ShowInTaskbar = false;  // Убираем иконку из панели задач
                ShowTrayNotification("Reminder Application", "The application is still running in the background.");
            }
        }


        // Метод для показа уведомления, даже когда окно свернуто
        private void ShowTrayNotification(string title, string message)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(5000); // Показываем уведомление на 5 секунд
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            // Удалите этот код из метода MainForm_Load
            // Application.SetCompatibleTextRenderingDefault(false);  // Этот вызов не нужен здесь

            // Дальнейшая инициализация и логика приложения
            string savedLanguage = Properties.Settings.Default.Language;
            if (string.IsNullOrEmpty(savedLanguage))
            {
                savedLanguage = "en";  // Устанавливаем язык по умолчанию
                Properties.Settings.Default.Language = savedLanguage;
                Properties.Settings.Default.Save();
            }

            CurrentLanguage = savedLanguage;
            Localization.LoadLanguage(CurrentLanguage);
            ApplyLocalization();
        }




        private void LoadSettings()
        {
            // Загрузите настройки из файла или другого хранилища
            SoundFilePath = Properties.Settings.Default.SoundFilePath; // Пример загрузки из настроек приложения
            if (string.IsNullOrEmpty(SoundFilePath))
            {
                SoundFilePath = "default.wav"; // Установим значение по умолчанию, если пусто
            }
        }
        private void SaveSettings()
        {
            // Сохраняем настройки в файл или другое хранилище
            Properties.Settings.Default.SoundFilePath = SoundFilePath; // Пример сохранения в настройки приложения
            Properties.Settings.Default.Save();
        }
    }
}