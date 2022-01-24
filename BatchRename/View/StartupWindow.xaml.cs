using BatchRename.Lib;
using BatchRename.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace BatchRename.View
{
    /// <summary>
    /// Interaction logic for IdleWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window, INotifyPropertyChanged
    {
        public string LoadStatusMessage { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private PluginManager _pluginManager { get; set; }
        private StartupEventArgs _startupEventArgs { get; set; }

        public StartupWindow(StartupEventArgs e)
        {
            InitializeComponent();

            _startupEventArgs = e;
            LoadStatusMessage = "Loading Batch Rename...";
            DataContext = this;
        }

        private void Configure()
        {
            BaseConfigure();

            if (_startupEventArgs.Args.Length > 1)
            {
                StartFromProject(_startupEventArgs.Args[1]);
            }

            if (_startupEventArgs.Args.Length == 0)
            {
                StartFromApp();
            }
        }

        private void BaseConfigure()
        {
            _pluginManager = new PluginManager("../../../Plugins");
        }

        private void StartFromProject(string path)
        {
            MainWindow mainWindow = new MainWindow(_pluginManager);
            mainWindow.LoadFrom(path);
            mainWindow.Show();
            Close();
        }

        private void StartFromApp()
        {
            RecentWindow recentWindow = new RecentWindow(_pluginManager);
            recentWindow.Show();
            Close();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Configure();
        }
    }
}
