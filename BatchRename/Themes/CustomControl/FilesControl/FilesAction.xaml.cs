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
        public event RoutedEventHandler OnAddFileClick;
        public event RoutedEventHandler OnAddFolderClick;
        public event RoutedEventHandler OnRemoveFileClick;

        public static readonly DependencyProperty ChooseOutputCommandProperty =
          DependencyProperty.Register(
              "ChooseOutputCommand",
              typeof(ICommand),
              typeof(FilesAction),
              new UIPropertyMetadata(null)
        );

        public ICommand ChooseOutputCommand
        {
            get { return (ICommand)GetValue(ChooseOutputCommandProperty); }
            set { SetValue(ChooseOutputCommandProperty, value); }
        }

        public FilesAction()
        {
            InitializeComponent();
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            OnAddFileClick?.Invoke(sender, e);
        }

        private void btnAddFolder_Click(object sender, RoutedEventArgs e)
        {
            OnAddFolderClick?.Invoke(sender, e);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            OnRemoveFileClick?.Invoke(sender, e);
        }
    }
}
