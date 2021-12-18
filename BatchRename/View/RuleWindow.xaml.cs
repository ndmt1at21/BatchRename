using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using BatchRename.Lib;
using BatchRename.Model;
using BatchRename.ViewModel;
using PluginContract;

namespace BatchRename.View
{
    public partial class RuleWindow : Window
    {
        private BindingList<EditingRuleViewModel> _ruleComponents { get; set; }
        private PluginManager _pluginManager { get; set; }
        private Store _store { get; set; }

        public RuleWindow(PluginManager pluginManager, Store store)
        {
            InitializeComponent();

            _ruleComponents = new BindingList<EditingRuleViewModel>();
            _pluginManager = pluginManager;
            _store = store;

            loadComponents();

            tabControlRule.ItemsSource = _ruleComponents;
        }

        private void loadComponents()
        {
            string[] pluginIds = _pluginManager.GetPluginIDs();

            foreach (string id in pluginIds)
            {
                _ruleComponents.Add(
                    new EditingRuleViewModel
                    {
                        RuleId = id,
                        Name = _pluginManager.GetRuleName(id),
                        Component = _pluginManager.CreateRuleComponent(id)
                    }); ;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EditingRuleViewModel viewModel = (EditingRuleViewModel)tabControlRule.SelectedItem;

            if (viewModel != null)
            {
                _store.CreatePickedRule(new RulePickedModel
                {
                    IsMarked = true,
                    RuleId = viewModel.RuleId,
                    Paramter = viewModel.Component.GetRuleParamter()
                });
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
