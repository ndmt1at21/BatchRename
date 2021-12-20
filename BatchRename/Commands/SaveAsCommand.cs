using BatchRename.Lib;
using BatchRename.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Commands
{
    public class SaveAsCommand : CommandBase
    {
        private Store _store { get; set; }
        private SaveService<ProjectStore> _saveService { get; set; }

        public SaveAsCommand(Store store, SaveService<ProjectStore> saveService)
        {
            _store = store;
            _saveService = saveService;
        }

        public override void Execute(object parameter)
        {
            Debug.WriteLine("In Save As");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Save As";
            saveFileDialog.DefaultExt = ".bare";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = "Batch Rename project (*.bare)|*.bare";

            if (saveFileDialog.ShowDialog() == true)
            {
                _saveService.Save(_store.ExportProjectStore(), saveFileDialog.FileName);
                _store.CurrentProjectPath = saveFileDialog.FileName;
                _store.IsSaveBefore = true;
                _store.IsBlankProject = false;
            }
        }
    }
}
