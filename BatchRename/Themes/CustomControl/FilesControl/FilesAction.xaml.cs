using BatchRename.Model;
using Microsoft.Win32;
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
using System.Windows.Navigation;

namespace BatchRename.Themes.CustomControl
{
    /// <summary>
    /// Interaction logic for FilesAction.xaml
    /// </summary>
    public partial class FilesAction : UserControl
    {
        private static List<string> _list = null;
        private List<Node> nodeList = null;
        public FilesAction()
        {
            InitializeComponent();
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                if (_list == null)
                {
                    _list = new List<string>(openFileDialog.FileNames);
                    nodeList = new List<Node>();
                }
                else
                    foreach (var file in openFileDialog.FileNames)
                    {
                        if (!_list.Contains(file))
                            _list.Add(file);
                    }
                foreach (var path in openFileDialog.FileNames)
                {
                    string extention = Path.GetExtension(path);
                    string filename = Path.GetFileName(path);
                    DateTime creation = File.GetCreationTime(path);
                    string size = extention.Length == 0 ? string.Empty : new System.IO.FileInfo(path).Length.ToString();
                    Node node = new Node()
                    {
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
