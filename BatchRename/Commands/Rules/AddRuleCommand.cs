using BatchRename.Lib;
using BatchRename.Model;
using BatchRename.View;
using BatchRename.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BatchRename.Commands.Rules
{
    public class AddRuleCommand : CommandBase
    {
        private Store _store { get; set; }
        private PluginManager _pluginManager { get; set; }

        public AddRuleCommand(Store store, PluginManager pluginManager)
        {
            _store = store;
            _pluginManager = pluginManager;
            Gesture = new KeyGesture(Key.F1);
        }

        public override void Execute(object parameter)
        {
            RuleWindow ruleWindow = new RuleWindow(_pluginManager, _store);
            ruleWindow.ShowDialog();
        }
    }
}
