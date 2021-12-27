using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using BatchRename.Model;
using BatchRename.ViewModel;

namespace BatchRename.Themes.CustomControl
{
    /// <summary>
    /// Interaction logic for FilesControl.xaml
    /// </summary>
    public partial class FilesControl : UserControl
    {
        public event MarkChangedEventHandler OnMarkChanged;
        public event SelectionChangedEventHandler OnSelectionChanged;

        public event RoutedEventHandler OnAddFileClick;
        public event RoutedEventHandler OnAddFolderClick;
        public event RoutedEventHandler OnRemoveFileClick;

        public static readonly DependencyProperty SelectedItemsProperty =
              DependencyProperty.Register(
                  "SelectedItems",
                  typeof(IList),
                  typeof(FilesControl),
                  new PropertyMetadata(new List<NodeConvertViewModel>())
        );

        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set
            {
                SetValue(SelectedItemsProperty, value);
            }
        }

        public IEnumerable<NodeConvertViewModel> ItemsSource
        {
            get
            {
                return (IEnumerable<NodeConvertViewModel>)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSource",
                typeof(IEnumerable<NodeConvertViewModel>),
                typeof(FilesControl)
            );

        public static readonly DependencyProperty ChooseOutputCommandProperty =
              DependencyProperty.Register(
                  "ChooseOutputCommand",
                  typeof(ICommand),
                  typeof(FilesControl),
                  new UIPropertyMetadata(null)
        );

        public ICommand ChooseOutputCommand
        {
            get { return (ICommand)GetValue(ChooseOutputCommandProperty); }
            set { SetValue(ChooseOutputCommandProperty, value); }
        }

        public FilesControl()
        {
            InitializeComponent();
        }

        private void FilesAction_OnAddFolderClick(object sender, RoutedEventArgs e)
        {
            OnAddFolderClick?.Invoke(sender, e);

        }

        private void FilesAction_OnAddFileClick(object sender, RoutedEventArgs e)
        {
            OnAddFileClick?.Invoke(sender, e);
        }

        private void FilesListView_OnMarkChanged(string markId)
        {
            OnMarkChanged?.Invoke(markId);
        }

        private void FilesListView_OnSelectionChanged()
        {
            SelectedItems = fileList.SelectedItems;
            OnSelectionChanged?.Invoke();
        }

        private void FilesAction_OnRemoveFileClick(object sender, RoutedEventArgs e)
        {
            OnRemoveFileClick?.Invoke(sender, e);
        }

        private void FilesListView_OnRemoveClick(object sender, RoutedEventArgs e)
        {
            OnRemoveFileClick?.Invoke(sender, e);
        }

    }
}
