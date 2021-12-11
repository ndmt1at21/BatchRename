using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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
using PluginContract;
using Utils;

namespace BatchRename.Themes.CustomControl
{
    public class RuleItem : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public partial class RuleListView : UserControl
    {
        public RuleListView()
        {
            InitializeComponent();
            DataContext = this;
            ItemsSource = new BindingList<RuleItem>();
            SelectedIndies = ImmutableList.Create<int>();
        }
    }

    // handle select
    public partial class RuleListView : INotifyPropertyChanged
    {
        public delegate void SelectionChangedEventHandler(IEnumerable<int> selectedIndies);
        public event SelectionChangedEventHandler OnSelectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<RuleItem> ItemsSource
        {
            get { return (BindingList<RuleItem>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                lvRules.ItemsSource = ItemsSource;
            }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(BindingList<RuleItem>), typeof(RuleListView));

        public ImmutableList<int> _selectedIndies;
        public ImmutableList<int> SelectedIndies
        {
            get
            {
                return _selectedIndies;
            }

            set
            {
                _selectedIndies = value;
                OnSelectedModelChanged();
            }
        }

        private void OnSelectedModelChanged()
        {
            if (OnSelectionChanged != null)
                OnSelectionChanged.Invoke(SelectedIndies);
        }

        private void headerCheckBox_Click(object sender, RoutedEventArgs e)
        {
            int countSelected = _selectedIndies.Count;
            int countAllItems = ItemsSource.Count;

            if (countSelected == countAllItems)
                DeSelectAll();

            if (countSelected >= 0 && countSelected < countAllItems)
                SelectAll();
        }

        private void cellCheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            DataGridRow parent = Utils.Control.GetParentViewItemFromChild<DataGridRow>(check);
            int index = lvRules.ItemContainerGenerator.IndexFromContainer(parent);

            var item = ItemsSource[index];

            if (SelectedIndies.IndexOf(item.Id) == -1)
            {
                SelectedIndies = SelectedIndies.Add(item.Id);
            }
            else
            {
                SelectedIndies = SelectedIndies.Where(id => id != item.Id).ToImmutableList();
            }
        }

        private void SelectAll()
        {
            SelectedIndies = ItemsSource.Select(src => src.Id).ToImmutableList();
        }

        private void DeSelectAll()
        {
            SelectedIndies = ImmutableList.Create<int>();
        }
    }
}
