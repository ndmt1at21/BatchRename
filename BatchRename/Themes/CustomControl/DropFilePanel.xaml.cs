using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BatchRename.Themes.CustomControl
{
    /// <summary>
    /// Interaction logic for DropFilePanel.xaml
    /// </summary>
    public partial class DropFilePanel : UserControl
    {
        public delegate void DelegateGetFiles(string[] files);
        public event DelegateGetFiles Handler;
        public bool DialogResult;
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

                Handler(files);
                DialogResult = true;
            }
        }

        internal bool ShowDialog()
        {
            //TODO: Change to Window control
            throw new NotImplementedException();
        }
    }
}
