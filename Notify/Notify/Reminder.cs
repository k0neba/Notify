using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    public class Reminder
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Link { get; set; }
        public DateTime ReminderTime { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsShown { get; set; }  // Флаг, показывающий, было ли показано напоминание
        public bool PlaySound { get; set; }  // Флаг для воспроизведения звука
        public string SoundFile { get; set; }  // Путь к звуковому файлу
    }

}
