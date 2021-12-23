using BatchRename.Lib;
using BatchRename.Model;
using BatchRename.Themes.CustomControl;
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

namespace BatchRename.View
{
    public partial class RecentWindow : Window
    {
        private Store _store { get; set; }

        public RecentWindow()
        {
            InitializeComponent();

            //_store = store;
            //_recentFileService = recentFileService;
            //RecentFileItems = _store.RecentFiles;

            //lvRecentProject.ItemsSource = RecentFileItems;
        }
    }
}