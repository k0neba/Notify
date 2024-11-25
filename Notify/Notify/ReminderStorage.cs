using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Notify
{
    public static class ReminderStorage
    {
        private static string filePath = "reminders.xml";

        public static (BindingList<Reminder>, string) LoadReminders(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Reminder>));
                    var reminders = (List<Reminder>)serializer.Deserialize(fs);
                    string language = "en"; // Здесь можно добавить логику для загрузки языка
                    return (new BindingList<Reminder>(reminders), language);
                }
            }
            return (new BindingList<Reminder>(), "en");
        }



        public static void SaveReminders(List<Reminder> reminders, string language, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Reminder>));
                serializer.Serialize(fs, reminders);
            }
        }
        public static void CheckAndDisplayReminders(BindingList<Reminder> reminders)
        {
            foreach (var reminder in reminders)
            {
                // Проверяем, если время напоминания прошло и оно не было показано
                if (reminder.ReminderTime <= DateTime.Now && !reminder.IsShown)
                {
                    // Показываем напоминание (это может быть окно, сообщение и т.д.)
                    MessageBox.Show($"{reminder.Title}\n{reminder.Comment}", "Напоминание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Устанавливаем, что оно показано
                    reminder.IsShown = true;
                }
            }
        }

    }
}
