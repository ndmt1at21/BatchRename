using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using System.Collections;
using BatchRename.ViewModel;

namespace BatchRename.Themes.CustomControl
{
    public partial class FilesListView : UserControl, INotifyPropertyChanged
    {
        public event MarkChangedEventHandler OnMarkChanged;
        public event SelectionChangedEventHandler OnSelectionChanged;
        public event RoutedEventHandler OnRemoveClick;
        public event RoutedEventHandler OnUpClick;
        public event RoutedEventHandler OnDownClick;

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

        public static readonly DependencyProperty SelectedItemsProperty =
              DependencyProperty.Register(
                  "SelectedItems",
                  typeof(IList),
                  typeof(FilesListView),
                  new PropertyMetadata(new List<NodeConvertViewModel>())
        );

        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public FilesListView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            OnRemoveClick?.Invoke(this, e);
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            OnDownClick?.Invoke(this, e);
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            OnUpClick?.Invoke(this, e);
        }
    }

    // handle select
    public partial class FilesListView
    {
        private void lvNodes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItems = lvNodes.SelectedItems;
            OnSelectionChanged?.Invoke();
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
