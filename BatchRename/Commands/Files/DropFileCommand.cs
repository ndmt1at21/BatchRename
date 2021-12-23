using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BatchRename.Commands.Files
{
    public class DropFileCommand : CommandBase
    {
        private Store _store { get; set; }
        private List<string> _list { get; set; }

        public DropFileCommand(Store store, List<string> list)
        {
            _store = store;
            _list = list;
        }

        public override void Execute(object parameter)
        {
            var e = (DragEventArgs)parameter;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                List<string> lastFileList = new List<string>(_list);

                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var file in files)
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


                foreach (var path in _list)
                {
                    if (!lastFileList.Contains(path))
                    {
                        string extention = Path.GetExtension(path);
                        string filename = Path.GetFileName(path);
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
                            IsMarked = true,
                            ConvertStatus = ConvertStatus.PENDING,
                        };

                        _store.CreateNodeConvert(nodeConvert);
                    }
                }
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
    }
}
