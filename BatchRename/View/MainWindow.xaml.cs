using BatchRename.Lib;
using BatchRename.Themes.CustomControl;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            loadPlugins();
        }

        private void loadPlugins()
        {
            PluginManager.Load("../../../Plugins");

            PluginManager.Shared.GetPluginIDs().Select(p =>
            {
                MessageBox.Show(p);
                return p;
            });
        }
    }
}