using BatchRename.Lib;
using BatchRename.Model;
using PluginContract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BatchRename.Commands
{
    public class ConvertCommand : CommandBase
    {
        private Store _store { get; set; }
        private PluginManager _pluginManager { get; set; }

        public ConvertCommand(Store store, PluginManager pluginManager)
        {
            _store = store;
            _pluginManager = pluginManager;

            Gesture = new KeyGesture(Key.F5);
        }


        public override void Execute(object parameter)
        {
            List<IRenameRule> rules = _store.GetAllPickedRule()
                .Where(pickedRule => pickedRule.IsMarked == true)
                .Select(pickedRule =>
                {
                    string ruleId = pickedRule.RuleId;

                    IRenameRule rule = _pluginManager.CreateRule(ruleId);
                    rule.SetParameter(pickedRule.Paramter);

                    return rule;
                }).ToList();

            List<NodeConvertModel> files = _store.GetAllNodeConverts();

            if (_store.PickedRules.Count == 0)
            {
                MessageBox.Show(
                   "No rule picked",
                   "Empty",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information
               );

                return;
            }

            if (_store.ConvertNodes.Count == 0)
            {
                MessageBox.Show(
                   "No file picked",
                   "Empty",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information
               );

                return;
            }

            ConvertPipeline pipeline = new ConvertPipeline(rules);

            pipeline.Convert(files, (result, err) =>
            {
                HandleFileConverted(result, err);
            });
        }

        private void HandleFileConverted(NodeConvertModel result, string err)
        {
            if (err == null)
            {
                result.ConvertStatus = ConvertStatus.SUCCESS;
                _store.UpdateNodeConvert(result);
            }


            if (err != null)
            {
                result.ConvertStatus = ConvertStatus.ERROR;
                _store.UpdateNodeConvert(result);
            }
        }
    }
}
