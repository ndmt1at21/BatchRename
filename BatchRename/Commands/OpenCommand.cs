using BatchRename.Lib;
using BatchRename.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BatchRename.Commands
{
    public class OpenCommand : CommandBase
    {
        private PluginManager _pluginManager { get; set; }

        public OpenCommand(PluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".bare";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Bare files (*.bare)|*.bare|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                MainWindow mainWindow = new MainWindow(_pluginManager);
                mainWindow.LoadFrom(openFileDialog.FileName);
                mainWindow.Show();
            }
        }
    }
}
