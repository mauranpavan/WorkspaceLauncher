using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;


namespace WorkspaceUI
{
    internal class StartupManager
    {
        private const string StartupRegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private static readonly string? ApplicationName = Application.Current.Resources["AppBrandName"] as string;

        public bool IsStartupEnabled()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(StartupRegistryKeyPath))
            {
                return key?.GetValue(ApplicationName) != null;
            }
        }

        public void EnableStartup(bool enable)
        {
            if (enable)
            {
                AddToStartup();
            }
            else
            {
                RemoveFromStartup();
            }
        }

        private void AddToStartup()
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(StartupRegistryKeyPath))
                {
                    var processModule = Process.GetCurrentProcess().MainModule;
                    if (processModule is { FileName: not null })
                    {
                        string executablePath = processModule.FileName;
                        if (executablePath != null) key.SetValue(ApplicationName, executablePath);
                    }
                }
                Debug.WriteLine("Application added to startup.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding to startup: {ex.Message}");
            }
        }

        private void RemoveFromStartup()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(StartupRegistryKeyPath, writable: true))
                {
                    if (key != null)
                    {
                        if (ApplicationName != null) key.DeleteValue(ApplicationName, throwOnMissingValue: false);
                    }
                }
                Debug.WriteLine("Application removed from startup.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error removing from startup: {ex.Message}");
            }
        }
    }


}
