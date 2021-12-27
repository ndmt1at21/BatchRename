using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PluginContract;
using Utils;
using BatchRename.Model;
using BatchRename.ViewModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace BatchRename.Themes.CustomControl
{
    public delegate void MouseDoubleClickRowHandler(string id);

    public partial class RuleListView : UserControl, INotifyPropertyChanged
    {
        public event MarkChangedEventHandler OnMarkChanged;
        public event SelectionChangedEventHandler OnSelectionChanged;
        public event RoutedEventHandler OnRemoveClick;
        public event RoutedEventHandler OnUpClick;
        public event RoutedEventHandler OnDownClick;

        public event PropertyChangedEventHandler PropertyChanged;

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
                typeof(RuleListView));

        public event MouseDoubleClickRowHandler OnRowDoubleClick;

        public static readonly DependencyProperty SelectedItemsProperty =
              DependencyProperty.Register(
                  "SelectedItems",
                  typeof(IList),
                  typeof(RuleListView),
                  new PropertyMetadata(new List<RulePickedViewModel>())
        );

        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public RuleListView()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void lvRules_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvRules.SelectedItem == null)
                return;

            var rule = (RulePickedViewModel)lvRules.SelectedItem;
            OnRowDoubleClick?.Invoke(rule.Id);
        }

        private void menuRemove_Click(object sender, RoutedEventArgs e)
        {
            OnRemoveClick?.Invoke(sender, e);
        }

        private void menuUp_Click(object sender, RoutedEventArgs e)
        {
            OnUpClick?.Invoke(sender, e);
        }

        private void menuDown_Click(object sender, RoutedEventArgs e)
        {
            OnDownClick?.Invoke(sender, e);
        }
    }

    // handle select
    public partial class RuleListView
    {
        private void lvRules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItems = lvRules.SelectedItems;
            OnSelectionChanged?.Invoke();
        }

        private void cellCheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            DataGridRow parent = Utils.Control.GetParentViewItemFromChild<DataGridRow>(check);
            int rowIndex = lvRules.ItemContainerGenerator.IndexFromContainer(parent);

            var item = ItemsSource.Where((_, index) => index == rowIndex).ToList()[0];

            OnMarkChanged?.Invoke(item.Id);
        }
    }
}
