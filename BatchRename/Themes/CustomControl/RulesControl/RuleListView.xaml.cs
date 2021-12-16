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

namespace BatchRename.Themes.CustomControl
{
    public partial class RuleListView : UserControl, INotifyPropertyChanged
    {
        public event MarkChangedEventHandler OnMarkChanged;
        public event SelectionChangedEventHandler OnSelectionChanged;
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

        public RuleListView()
        {
            InitializeComponent();
            DataContext = this;
        }
    }

    // handle select
    public partial class RuleListView
    {
        private void lvRules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIds = new List<string>();

            foreach (var item in lvRules.SelectedItems)
            {
                var ruleModel = (RulePickedViewModel)item;
                selectedIds.Add(ruleModel.Id);
            }

            OnSelectionChanged?.Invoke(selectedIds);
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
