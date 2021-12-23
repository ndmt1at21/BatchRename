using BatchRename.Lib;
using BatchRename.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Save As";
            saveFileDialog.DefaultExt = ".bare";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = "Batch Rename project (*.bare)|*.bare";
            saveFileDialog.FileName = Path.GetFileName(_store.CurrentProjectPath);

            if (saveFileDialog.ShowDialog() == true)
            {
                string savePath = saveFileDialog.FileName;

                _saveService.Save(_store.ExportProjectStore(), savePath);
                _store.CurrentProjectPath = savePath;
                _store.IsSaveBefore = true;
                _store.IsBlankProject = false;
                _store.HasContentUnsaved = false;


                RecentFiles.Shared.AddRecent(_store.CurrentProjectPath);
            }
        }
    }
}
