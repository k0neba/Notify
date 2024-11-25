using System;
using System.IO;

namespace Notify
{
    public static class ShortcutHelper
    {
        public static void CreateShortcut()
        {
            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = Path.Combine(startupFolderPath, "NotifyApp.bat");
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (!File.Exists(shortcutPath))
            {
                using (StreamWriter writer = new StreamWriter(shortcutPath))
                {
                    writer.WriteLine($"@echo off");
                    writer.WriteLine($"start \"\" \"{exePath}\"");
                }
            }
        }

        public static void RemoveShortcut()
        {
            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = Path.Combine(startupFolderPath, "NotifyApp.bat");

            if (File.Exists(shortcutPath))
            {
                File.Delete(shortcutPath);
            }
        }

        public static bool IsShortcutExists()
        {
            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = Path.Combine(startupFolderPath, "NotifyApp.bat");

            return File.Exists(shortcutPath);
        }
    }
}
