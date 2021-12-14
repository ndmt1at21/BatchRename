using BatchRename.Lib;
using BatchRename.Model;
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
        private PluginManager _pluginManager { get; set; }
        private Store _store;

        public MainWindow(PluginManager pluginManager, Store store)
        {
            InitializeComponent();
            _pluginManager = pluginManager;
            _store = store;
        }

        private void Container_DragEnter(object sender, DragEventArgs e)
        {
            //TODO: Show drag drop panel
        }

        private void Container_DragLeave(object sender, DragEventArgs e)
        {
            //TODO: Hid drag and drop panel
        }

        private void FilesControl_OnAddFileClick(object sender, RoutedEventArgs e)
        {

        }
    }

    // HANDLE RuleControl
    public partial class MainWindow
    {
        private void RuleControl_OnAddClick(object sender, RoutedEventArgs e)
        {
            string[] pluginIds = _pluginManager.GetPluginIDs();

            List<RuleComponent> ruleComponents = new List<RuleComponent>();

            foreach (string id in pluginIds)
            {
                ruleComponents.Add(
                    new RuleComponent
                    {
                        Id = id,
                        Name = _pluginManager.GetRuleName(id),
                        Component = _pluginManager.CreateRuleComponent(id)
                    });
            }

            RuleWindow ruleWindow = new RuleWindow(ruleComponents, _store);
            ruleWindow.ShowDialog();
        }

        private void RuleControl_OnRemoveClick(object sender, RoutedEventArgs e)
        {
            // TODO: Remove
        }
    }
}