using BatchRename.Lib;
using BatchRename.Model;
using PluginContract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            List<FileInfor> files = _store.GetAllNodeConverts()
                .Where(nodeConvert => nodeConvert.IsMarked == true)
                .Select(nodeConvert =>
                {
                    return new FileInfor
                    {
                        FileName = nodeConvert.Node.Name,
                        Dir = nodeConvert.Node.Path,
                        Extension = nodeConvert.Node.Extension
                    };
                })
                .ToList();

            ConvertPipeline pipeline = new ConvertPipeline(rules);

            pipeline.Convert(files, (result, err) =>
            {
                Debug.WriteLine(result.FileName);
                Debug.WriteLine(err);
            });
        }
    }
}
