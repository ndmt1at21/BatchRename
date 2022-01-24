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
using BatchRename.Commands.Rules;
using BatchRename.Lib;
using BatchRename.Model;
using BatchRename.ViewModel;
using PluginContract;

namespace BatchRename.View
{
    public partial class RuleWindow : Window, INotifyPropertyChanged
    {
        private BindingList<EditingRuleViewModel> _ruleComponents { get; set; }
        private PluginManager _pluginManager { get; set; }
        private Store _store { get; set; }
        private string _startId;

        public bool IsCreatedNew => _startId == null;
        public string MainButtonText => IsCreatedNew ? "Add Rule" : "Update Rule";

        public event PropertyChangedEventHandler PropertyChanged;

        public RuleWindow(PluginManager pluginManager, Store store, string startId = null)
        {
            InitializeComponent();

            _ruleComponents = new BindingList<EditingRuleViewModel>();
            _pluginManager = pluginManager;
            _store = store;
            _startId = startId;

            loadComponents();

            tabControlRule.ItemsSource = _ruleComponents;
            DataContext = this;
        }

        private void loadComponents()
        {
            if (_startId != null)
            {
                LoadFromStoreByRuleModeId();
            }

            if (_startId == null)
            {
                LoadAllFromPluginManager();
            }
        }

        private void LoadFromStoreByRuleModeId()
        {
            RulePickedModel ruleModel = _store.GetPickedRule(_startId);
            string ruleName = _pluginManager.GetRuleName(ruleModel.RuleId);

            IRuleComponent ruleComponent = _pluginManager.CreateRuleComponent(ruleModel.RuleId);
            ruleComponent.SetRuleParameter(ruleModel.Paramter);

            _ruleComponents.Add(
                    new EditingRuleViewModel
                    {
                        RuleId = ruleModel.RuleId,
                        Name = ruleName,
                        Component = ruleComponent
                    });
        }

        private void LoadAllFromPluginManager()
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
                    });
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowPosition position = _store.DialogSelectRulePosition;

            Left = position.Left;
            Top = position.Top;
            Width = position.Width;
            Height = position.Height;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EditingRuleViewModel viewModel = (EditingRuleViewModel)tabControlRule.SelectedItem;

            if (viewModel != null && IsCreatedNew)
            {
                _store.CreatePickedRule(new RulePickedModel
                {
                    IsMarked = true,
                    RuleId = viewModel.RuleId,
                    Paramter = viewModel.Component.GetRuleParamter()
                });
            }

            if (viewModel != null && !IsCreatedNew)
            {
                _store.UpdatePickedRule(new RulePickedUpdateModel
                {
                    Id = _startId,
                    Paramter = viewModel.Component.GetRuleParamter()
                });
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var window = (Window)sender;

            _store.UpdateDialogSelectRulePosition(new WindowPosition
            {
                Top = window.Top,
                Left = window.Left,
                Width = e.NewSize.Width,
                Height = e.NewSize.Height
            });
        }
    }
}
