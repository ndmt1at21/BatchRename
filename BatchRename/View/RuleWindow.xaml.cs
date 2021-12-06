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
        public List<RuleComponent> RuleComponents;

        private BindingList<TabItem> tabItems = new BindingList<TabItem>();

        public RuleWindow(List<RuleComponent> ruleComponents)
        {
            InitializeComponent();

            if (ruleComponents == null)
                return;

            RuleComponents = ruleComponents;

            foreach (var ruleComponent in RuleComponents)
            {
                tabItems.Add(new TabItem
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
            tabControlRule.ItemsSource = tabItems;
        }
    }
}
