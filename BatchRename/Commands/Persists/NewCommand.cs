
using BatchRename.Lib;
using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BatchRename.Commands
{
    public class NewCommand : CommandBase
    {
        private PluginManager _pluginManager;

        public NewCommand(PluginManager pluginManager)
        {
            _pluginManager = pluginManager;

            Gesture = new KeyGesture(Key.N, ModifierKeys.Control);
        }

        public override void Execute(object parameter)
        {
            MainWindow.ProjectNumber++;
            MainWindow mainWindow = new MainWindow(_pluginManager);
            mainWindow.Show();
        }
    }
}
