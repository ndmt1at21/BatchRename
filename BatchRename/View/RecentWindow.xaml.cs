using BatchRename.Lib;
using BatchRename.Model;
using BatchRename.Themes.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace BatchRename.View
{
    public partial class RecentWindow : Window
    {
        public BindingList<RecentFileItem> Files { get; set; }
        private PluginManager _pluginManager { get; set; }

        public RecentWindow(PluginManager pluginManager)
        {
            InitializeComponent();

            _pluginManager = pluginManager;
            Files = new BindingList<RecentFileItem>(RecentFiles.Shared.GetRecentFiles().Items);
            DataContext = this;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = (ListView)sender;

            var selectedItem = (RecentFileItem)listView.SelectedItem;
            string path = selectedItem.Path;

            if (!File.Exists(path))
            {
                MessageBox.Show("Project is deleted");
                return;
            }

            if (!(Path.GetExtension(path) != "bare"))
            {
                MessageBox.Show("Invalid file format");
                return;
            }

            MainWindow mainWindow = new MainWindow(_pluginManager);
            mainWindow.LoadFrom(path);
            mainWindow.Show();

            Close();
        }
    }
}