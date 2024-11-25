using System;
using Microsoft.Win32;

namespace Notify
{
    public static class AutoStartHelper
    {
        private const string RegistryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string AppName = "NotifyApp";

        public static void AddToStartup()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                key.SetValue(AppName, exePath);
            }
        }

        public static void RemoveFromStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                key.DeleteValue(AppName, false);
            }
        }

        public static bool IsInStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, false))
            {
                return key.GetValue(AppName) != null;
            }
        }
    }
}
