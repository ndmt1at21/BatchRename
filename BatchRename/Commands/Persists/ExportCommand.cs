using BatchRename.Lib;
using BatchRename.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BatchRename.Commands
{
    public class ExportCommand : CommandBase
    {
        private Store _store { get; set; }
        private SaveService<RulePreset> _saveService { get; set; }

        public ExportCommand(Store store, SaveService<RulePreset> saveService)
        {
            _store = store;
            _saveService = saveService;

            Gesture = new KeyGesture(Key.E, ModifierKeys.Control);
        }

        public override void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Export Preset";
            saveFileDialog.DefaultExt = ".brpreset";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = "Batch Rename preset (*.brpreset)|*.brpreset";

            if (saveFileDialog.ShowDialog() == true)
            {
                RulePreset preset = new RulePreset
                {
                    PickedRules = _store.GetAllPickedRule()
                };

                _saveService.Save(preset, saveFileDialog.FileName);
            }
        }
    }
}
