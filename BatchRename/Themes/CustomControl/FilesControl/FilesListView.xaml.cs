using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
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
using BatchRename.ViewModel;

namespace BatchRename.Themes.CustomControl
{
    public partial class FilesListView : UserControl, INotifyPropertyChanged
    {
        public event MarkChangedEventHandler OnMarkChanged;
        public event SelectionChangedEventHandler OnSelectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

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
                typeof(FilesListView)
            );

        public FilesListView()
        {
            InitializeComponent();
            DataContext = this;
        }
    }

    // handle select
    public partial class FilesListView
    {
        private void lvNodes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIds = new List<string>();

            foreach (var item in lvNodes.SelectedItems)
            {
                var nodeConvert = (NodeConvertViewModel)item;
                selectedIds.Add(nodeConvert.Id);
            }

            OnSelectionChanged?.Invoke(selectedIds);
        }

        private void cellCheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            DataGridRow parent = Utils.Control.GetParentViewItemFromChild<DataGridRow>(check);
            int rowIndex = lvNodes.ItemContainerGenerator.IndexFromContainer(parent);

            var item = ItemsSource.Where((_, index) => index == rowIndex).ToList()[0];

            OnMarkChanged?.Invoke(item.Id);
        }
    }
}
