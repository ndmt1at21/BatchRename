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
using System.Windows.Shapes;
using BatchRename.Model;
using PluginContract;

namespace BatchRename.View
{
    public class RuleComponent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IRuleComponent Component { get; set; }
    }

    public partial class RuleWindow : Window
    {
        private List<RuleComponent> _ruleComponents;
        private BindingList<TabItem> _tabItems = new BindingList<TabItem>();
        private Store _store;

        public RuleWindow(List<RuleComponent> ruleComponents, Store store)
        {
            InitializeComponent();

            if (ruleComponents == null)
                return;

            _ruleComponents = ruleComponents;
            _store = store;

            foreach (var ruleComponent in _ruleComponents)
            {
                _tabItems.Add(new TabItem
                {
                    Header = ruleComponent.Name,
                    Content = ruleComponent.Component
                });
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tabControlRule.ItemsSource = _tabItems;
        }

      

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
