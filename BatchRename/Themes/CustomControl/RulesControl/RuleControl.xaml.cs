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
using BatchRename.Model;
using BatchRename.ViewModel;

namespace BatchRename.Themes.CustomControl
{
    public partial class RuleControl : UserControl
    {
        public event MarkChangedEventHandler OnMarkChanged;
        public event SelectionChangedEventHandler OnSelectionChanged;

        public event RoutedEventHandler OnDownClick;
        public event RoutedEventHandler OnUpClick;
        public event RoutedEventHandler OnAddClick;
        public event RoutedEventHandler OnRemoveClick;

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
                typeof(RuleControl)
            );

        public RuleControl()
        {
            InitializeComponent();
        }

        private void RuleListView_OnMarkChanged(string markId)
        {
            OnMarkChanged?.Invoke(markId);
        }

        private void RuleListView_OnSelectionChanged(IEnumerable<string> selectedIds)
        {
            SelectedIds = selectedIds;
            OnSelectionChanged?.Invoke(selectedIds);
        }

        private void RuleAction_OnAddClick(object sender, RoutedEventArgs e)
        {
            OnAddClick?.Invoke(sender, e);
        }

        private void RuleAction_OnDownClick(object sender, RoutedEventArgs e)
        {
            OnDownClick?.Invoke(sender, e);
        }

        private void RuleAction_OnUpClick(object sender, RoutedEventArgs e)
        {
            OnUpClick?.Invoke(sender, e);
        }

        private void RuleAction_OnRemoveClick(object sender, RoutedEventArgs e)
        {
            OnRemoveClick?.Invoke(sender, e);
        }
    }
}
