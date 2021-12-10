using BatchRename.Lib;
using BatchRename.Themes.CustomControl;
using BatchRename.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<RuleItem> ItemsSource { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRuleWindow_Click(object sender, RoutedEventArgs e)
        {
            string[] pluginIds = PluginManager.Shared.GetPluginIDs();

            List<RuleComponent> ruleComponents = new List<RuleComponent>();

            foreach (string id in pluginIds)
            {
                ruleComponents.Add(
                    new RuleComponent
                    {
                        Id = id,
                        Name = PluginManager.Shared.GetRuleName(id),
                        Component = PluginManager.Shared.CreateRuleComponent(id)
                    });
                Debug.WriteLine(id);
            }



            RuleWindow ruleWindow = new RuleWindow(ruleComponents);

            ruleWindow.Show();
        }

        private void Container_DragEnter(object sender, DragEventArgs e)
        {
            //TODO: Show drag drop panel
        }

        private void Container_DragLeave(object sender, DragEventArgs e)
        {
            //TODO: Hid drag and drop panel
        }

    }
}