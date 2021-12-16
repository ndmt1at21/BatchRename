using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BatchRename.Themes.CustomControl
{
    /// <summary>
    /// Interaction logic for DropFilePanel.xaml
    /// </summary>
    public partial class DropFilePanel : Window
    {
        private static List<string> _list = null;
        private List<Node> nodeList = null;
        public DropFilePanel()
        {
            InitializeComponent();
        }

        private void DragDrop_Function(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ///TODO: Handle find here
                ///
                if (_list == null)
                {
                    _list = new List<string>(files);
                    nodeList = new List<Node>();
                }
                else
                    foreach (var file in files)
                    {
                        if (!_list.Contains(file))
                            _list.Add(file);
                    }
                foreach (var path in _list)
                {

                    string extention = Path.GetExtension(path);
                    string filename = Path.GetFileName(path);
                    DateTime creation = File.GetCreationTime(path);
                    string size = extention.Length == 0 ? string.Empty : new System.IO.FileInfo(path).Length.ToString();
                    Node node = new Node(){
                        Path = path,
                        Extension = extention,
                        Name = Name,
                        CreatedDate = creation,
                        Size = size
                    };
                    nodeList.Add(node);
                }
            }
        }
    }
}
