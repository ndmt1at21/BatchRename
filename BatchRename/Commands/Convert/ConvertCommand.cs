using BatchRename.Lib;
using BatchRename.Model;
using PluginContract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private Dictionary<string, string> _filePaths { get; set; }

        public ConvertCommand(Store store, PluginManager pluginManager)
        {
            _store = store;
            _pluginManager = pluginManager;
            _filePaths = new Dictionary<string, string>();

            Gesture = new KeyGesture(Key.F5);
        }

        public override void Execute(object parameter)
        {
            List<IRenameRule> rules = GetRulePicked();
            List<NodeConvertModel> files = GetNodePicked();

            ValidateBeforeConvert(rules, files);

            ConvertPipeline pipeline = new ConvertPipeline(rules);
            pipeline.Convert(files, (result, err) =>
            {
                HandleFileConverted(result, err);
            });
        }

        private List<IRenameRule> GetRulePicked()
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

            return rules;
        }

        private List<NodeConvertModel> GetNodePicked()
        {
            List<NodeConvertModel> files = _store.GetAllNodeConverts()
                .Where(node => node.IsMarked == true)
                .ToList();

            return files;
        }

        private void HandleFileConverted(NodeConvertModel result, string err)
        {
            if (err == null)
                HandleFileConvertedSuccess(result);

            if (err != null)
                HandleFileConvertedError(result, err);
        }

        private void HandleFileConvertedSuccess(NodeConvertModel result)
        {
            try
            {
                CopyFile(result.Node.Path, _store.OutputPath, result.NewName);
                result.ConvertStatus = ConvertStatus.SUCCESS;
                _store.UpdateNodeConvert(result);
            }
            catch (Exception ex)
            {
                result.ConvertStatus = ConvertStatus.ERROR;
                result.Error = ex.Message;
                _store.UpdateNodeConvert(result);
            }
        }

        private void HandleFileConvertedError(NodeConvertModel result, string err)
        {
            result.ConvertStatus = ConvertStatus.ERROR;
            result.Error = err;
            _store.UpdateNodeConvert(result);
        }

        private void CopyFile(string from, string outDir, string newName)
        {
            Utils.File.MoveFile(from, outDir, newName);
        }

        private void ValidateBeforeConvert(List<IRenameRule> rules, List<NodeConvertModel> files)
        {
            if (rules.Count == 0)
            {
                MessageBox.Show(
                   "No rule picked",
                   "Empty",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information
               );

                return;
            }

            if (files.Count == 0)
            {
                MessageBox.Show(
                   "No file picked",
                   "Empty",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information
               );

                return;
            }

            if (_store.OutputPath == null)
            {
                MessageBox.Show(
                   "Output Path has not picked",
                   "Empty",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information
               );

                return;
            }
        }
    }
}
