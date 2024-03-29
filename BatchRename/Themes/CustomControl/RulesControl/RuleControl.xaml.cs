﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
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
    public partial class RuleControl : UserControl, INotifyPropertyChanged
    {
        public event MarkChangedEventHandler OnMarkChanged;
        public event SelectionChangedEventHandler OnSelectionChanged;

        public event RoutedEventHandler OnDownClick;
        public event RoutedEventHandler OnUpClick;
        public event RoutedEventHandler OnAddClick;
        public event RoutedEventHandler OnRemoveClick;

        public event MouseDoubleClickRowHandler OnRowDoubleClick;
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
                typeof(RuleControl)
            );

        public static readonly DependencyProperty AddRuleCommandProperty =
          DependencyProperty.Register(
              "AddRuleCommand",
              typeof(ICommand),
              typeof(RuleControl),
              new UIPropertyMetadata(null)
        );

        public ICommand AddRuleCommand
        {
            get { return (ICommand)GetValue(AddRuleCommandProperty); }
            set { SetValue(AddRuleCommandProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsProperty =
          DependencyProperty.Register(
              "SelectedItems",
              typeof(IList),
              typeof(RuleControl),
              new PropertyMetadata(new List<NodeConvertViewModel>())
        );

        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public RuleControl()
        {
            InitializeComponent();
        }

        private void RuleListView_OnMarkChanged(string markId)
        {
            OnMarkChanged?.Invoke(markId);
        }

        private void RuleListView_OnSelectionChanged()
        {
            SelectedItems = lvRules.SelectedItems;
            OnSelectionChanged?.Invoke();
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

        private void RuleListView_OnRowDoubleClick(string id)
        {
            OnRowDoubleClick?.Invoke(id);
        }

        private void BRButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddRuleCommand.Execute(null);
        }

        private void RuleListView_OnDownClick(object sender, RoutedEventArgs e)
        {
            OnDownClick?.Invoke(sender, e);
        }

        private void RuleListView_OnUpClick(object sender, RoutedEventArgs e)
        {
            OnUpClick?.Invoke(sender, e);
        }

        private void RuleListView_OnRemoveClick(object sender, RoutedEventArgs e)
        {
            OnRemoveClick?.Invoke(sender, e);
        }
    }
}
