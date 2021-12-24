using BatchRename.Lib;
using BatchRename.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BatchRename.Commands
{
    public class ImportCommand : CommandBase
    {
        private Store _store { get; set; }
        private LoadService<RulePreset> _loadService { get; set; }

        public ImportCommand(Store store, LoadService<RulePreset> loadService)
        {
            _store = store;
            _loadService = loadService;

            Gesture = new KeyGesture(Key.I, ModifierKeys.Control);
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".brpreset";
            openFileDialog.Title = "Import Preset";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Bare presets (*.brpreset)|*.brpreset|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    RulePreset preset = _loadService.Load(openFileDialog.FileName);
                    _store.PickedRules.Clear();

                    foreach (var rule in preset.PickedRules)
                    {
                        _store.CreatePickedRule(new RulePickedModel
                        {
                            IsMarked = rule.IsMarked,
                            Paramter = rule.Paramter,
                            Position = rule.Position,
                            RuleId = rule.RuleId,
                        });
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid preset file");
                }
            }
        }
    }
}
