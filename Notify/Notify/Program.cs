using System;
using System.Windows.Forms;

namespace Notify
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // ������������� ������������� � ����������� ������.
            Application.SetCompatibleTextRenderingDefault(false); 

            // �������� ���������� ����� ��� UI.
            Application.EnableVisualStyles();

            // ��������� �������� ���� �����.
            Application.Run(new MainForm()); 
        }
    }
}
