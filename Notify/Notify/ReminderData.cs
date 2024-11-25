using Notify;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public class ReminderData
{
    public string CurrentLanguage { get; set; }
    public List<Reminder> Reminders { get; set; }

    public ReminderData()
    {
        Reminders = new List<Reminder>(); // Инициализация списка напоминаний
    }
}
