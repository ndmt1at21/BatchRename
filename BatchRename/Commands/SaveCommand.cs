using BatchRename.Lib;
using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Commands
{
    public class SaveCommand : CommandBase
    {
        private Store _store { get; set; }
        private SaveService<ProjectStore> _saveService { get; set; }

        public SaveCommand(Store store, SaveService<ProjectStore> saveService)
        {
            _store = store;
            _saveService = saveService;
        }

        public override void Execute(object parameter)
        {
            string savePath = _store.CurrentProjectPath;

            if (string.IsNullOrEmpty(savePath))
                return;

            _saveService.Save(_store.ExportProjectStore(), savePath);
            _store.CurrentProjectPath = savePath;
            _store.IsSaveBefore = true;
            _store.IsBlankProject = false;
        }
    }
}
