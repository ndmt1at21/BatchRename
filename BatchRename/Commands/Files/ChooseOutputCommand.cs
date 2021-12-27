using BatchRename.Model;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Commands.Files
{
    public class ChooseOutputCommand : CommandBase
    {
        private Store _store { get; set; }

        public ChooseOutputCommand(Store store)
        {
            _store = store;
        }

        public override void Execute(object parameter)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Multiselect = true;
            dialog.IsFolderPicker = true;
            dialog.EnsurePathExists = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                _store.OutputPath = dialog.FileName;
            }
        }
    }
}
