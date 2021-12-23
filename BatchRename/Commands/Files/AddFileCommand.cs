using BatchRename.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BatchRename.Commands.Files
{
    public class AddFileCommand : CommandBase
    {
        private Store _store { get; set; }
        private List<string> _list { get; set; }

        public AddFileCommand(Store store, List<string> list)
        {
            _store = store;
            _list = list;
            Gesture = new KeyGesture(Key.F6);
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {

                foreach (var path in openFileDialog.FileNames)
                {
                    if (!_list.Contains(path))
                    {
                        _list.Add(path);
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
            }
        }
    }
}
