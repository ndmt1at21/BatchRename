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
    public class PreviewCommand : CommandBase
    {
        private Store _store { get; set; }
        private PluginManager _pluginManager { get; set; }

        public PreviewCommand(Store store, PluginManager pluginManager)
        {
            _store = store;
            _pluginManager = pluginManager;
        }


        public override void Execute(object parameter)
        {
            List<IRenameRule> rules = _store.GetAllPickedRule()
                .Where(pickedRule => pickedRule.IsMarked == true)
                .Select(pickedRule =>
                {
                    IRenameRule rule = _pluginManager.CreateRule(pickedRule.RuleId);
                    rule.SetParameter(pickedRule.Paramter);
                    return rule;
                }).ToList();

            List<NodeConvertModel> files = _store.GetAllNodeConverts();

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
                _store.UpdateNodeConvert(result);
            }


            if (err != null)
            {
                result.Error = err;
                _store.UpdateNodeConvert(result);
            }
        }
    }
}
