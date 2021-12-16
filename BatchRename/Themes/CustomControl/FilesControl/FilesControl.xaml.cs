using System;
using System.Collections.Generic;
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

        public IEnumerable<string> SelectedIds;

        public IEnumerable<RulePickedViewModel> ItemsSource
        {
            get
            {
                return (IEnumerable<RulePickedViewModel>)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSource",
                typeof(IEnumerable<RulePickedViewModel>),
                typeof(FilesControl)
            );

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

        private void FilesListView_OnSelectionChanged(IEnumerable<string> selectedIds)
        {
            SelectedIds = selectedIds;
            OnSelectionChanged?.Invoke(selectedIds);
        }
    }
}
