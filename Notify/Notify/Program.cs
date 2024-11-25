using System;
using System.Windows.Forms;

namespace Notify
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Устанавливаем совместимость с рендерингом текста.
            Application.SetCompatibleTextRenderingDefault(false); 

            // Включаем визуальные стили для UI.
            Application.EnableVisualStyles();

            // Запускаем основное окно формы.
            Application.Run(new MainForm()); 
        }
    }
}
