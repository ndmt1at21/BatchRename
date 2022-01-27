using BatchRename.Model;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace BatchRename.Commands.Files
{
    public class AddFolderCommand : CommandBase
    {
        private Store _store { get; set; }
        private List<string> _list { get; set; }

        public AddFolderCommand(Store store, List<string> list)
        {
            _store = store;
            _list = list;

            Gesture = new KeyGesture(Key.F7);
        }

        public override void Execute(object parameter)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Multiselect = true;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                HandleImportFiles(dialog.FileNames.ToList());
            }
        }

        private void handleFolder(string path)
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                if (!_list.Contains(fileName))
                    _list.Add(fileName);
            }
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(path);
            foreach (string subdirectory in subdirectoryEntries)
                handleFolder(subdirectory);
        }

        private void HandleImportFiles(List<string> FileNames)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(() =>
            {
                //Save old files
                List<string> lastFileList = new List<string>(_list);
                //New files
                List<string> arrAllFiles = new List<string>(FileNames);

                foreach (var file in arrAllFiles)
                {
                    if (!_list.Contains(file))
                    {
                        if (File.Exists(file))
                        {
                            // This path is a file
                            if (!_list.Contains(file))
                                _list.Add(file);
                        }
                        else if (Directory.Exists(file))
                        {
                            // This path is a directory
                            handleFolder(file);
                        }
                    }
                }

                // To store
                foreach (var path in _list)
                {
                    if (!lastFileList.Contains(path))
                    {
                        string extention = Path.GetExtension(path);
                        string filename = Path.GetFileNameWithoutExtension(path);
                        DateTime creation = File.GetCreationTime(path);
                        string size = extention.Length == 0 ? string.Empty : new System.IO.FileInfo(path).Length.ToString();

                        Node node = new Node()
                        {
                            Path = path,
                            Extension = extention,
                            Name = filename,
                            CreatedDate = creation,
                            Size = size
                        };

                        NodeConvertModel nodeConvert = new NodeConvertModel()
                        {
                            Node = node,
                            ConvertStatus = ConvertStatus.PENDING,
                            IsMarked = true,
                        };

                        _store.CreateNodeConvert(nodeConvert);
                    }
                }
            });
        }
    }
}
