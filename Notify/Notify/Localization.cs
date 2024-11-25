namespace Notify
{
    public static class Localization
    {
        public static string CurrentLanguage { get; private set; }
        private static Dictionary<string, string> _translations = new Dictionary<string, string>();

        public static void LoadLanguage(string language)
        {
            // Очищаем словарь перед загрузкой новых данных
            _translations.Clear();
            CurrentLanguage = language;

            // Локализация для украинского языка
            if (language == "uk")
            {
                AddTranslation("MainFormTitle", "Головна форма");
                AddTranslation("ChangeLanguageButton", "Змінити мову");
                AddTranslation("CreateReminderButton", "Створити нагадування");
                AddTranslation("EditReminderButton", "Редагувати нагадування");
                AddTranslation("DeleteReminderButton", "Видалити нагадування");
                AddTranslation("EditReminderFormTitle", "Сторінка змін");
                AddTranslation("CreateReminderFormTitle", "Сторінка створення");
                AddTranslation("Save", "Зберегти");
                AddTranslation("Cancel", "Скасувати");
                AddTranslation("TitleLabel", "Заголовок");
                AddTranslation("CommentLabel", "Коментар");
                AddTranslation("LinkLabel", "Посилання");
                AddTranslation("DateLabel", "Час нагадування");
                AddTranslation("Time", "Год та хвилини");
                AddTranslation("SettingsButton", "Налаштування");
                AddTranslation("SettingsFormTitle", "Налаштування");
                AddTranslation("SoundFileLabel", "Звуковий файл");
                AddTranslation("AutoStartCheckBox", "Автозапуск");
                AddTranslation("SaveButton", "Зберегти");
                AddTranslation("CancelButton", "Скасувати");
            }
            // Локализация для английского языка
            else if (language == "en")
            {
                AddTranslation("MainFormTitle", "Main Form");
                AddTranslation("ChangeLanguageButton", "Change Language");
                AddTranslation("CreateReminderButton", "Create Reminder");
                AddTranslation("EditReminderButton", "Edit Reminder");
                AddTranslation("DeleteReminderButton", "Delete Reminder");
                AddTranslation("EditReminderFormTitle", "Edit");
                AddTranslation("CreateReminderFormTitle", "Create");
                AddTranslation("Save", "Save");
                AddTranslation("Cancel", "Cancel");
                AddTranslation("TitleLabel", "Title");
                AddTranslation("CommentLabel", "Comment");
                AddTranslation("LinkLabel", "Link");
                AddTranslation("DateLabel", "Reminder Time");
                AddTranslation("Time", "Hour and Minutes");
                AddTranslation("SettingsFormTitle", "Settings");
                AddTranslation("SoundFileLabel", "Sound File");
                AddTranslation("AutoStartCheckBox", "Auto Start");
                AddTranslation("SaveButton", "Save");
                AddTranslation("CancelButton", "Cancel");
                AddTranslation("SettingsButton", "Settings");
            }
        }

        private static void AddTranslation(string key, string value)
        {
            // Добавляем перевод в словарь, если его еще нет
            if (!_translations.ContainsKey(key))
            {
                _translations.Add(key, value);
            }
        }

        public static string GetString(string key)
        {
            // Возвращаем строку по ключу, если ключ найден в словаре
            return _translations.ContainsKey(key) ? _translations[key] : key;
        }
    }
}
