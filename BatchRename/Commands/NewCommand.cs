﻿
using BatchRename.Lib;
using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Commands
{
    public class NewCommand : CommandBase
    {
        private PluginManager _pluginManager;

        public NewCommand(PluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        public override void Execute(object parameter)
        {
            MainWindow mainWindow = new MainWindow(_pluginManager);
            mainWindow.Show();
        }
    }
}
