using BatchRename.Lib;
using BatchRename.Model;
using BatchRename.Themes.CustomControl;
using BatchRename.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BatchRename
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "BRRename"
            );

            string recentFilesPath = Path.Combine(appDataPath, "RecentFiles", "recent.json");
            string backupPath = Path.Combine(appDataPath, "BackupFiles");

            Debug.WriteLine(recentFilesPath);

            Environment.SetEnvironmentVariable("AppDataPath", appDataPath);
            Environment.SetEnvironmentVariable("RecentFilesPath", recentFilesPath);
            Environment.SetEnvironmentVariable("BackupFilesPath", backupPath);

            StartupWindow startupWindow = new StartupWindow(e);
            startupWindow.Show();
        }
    }
}
