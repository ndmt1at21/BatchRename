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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BatchRename.Themes.CustomControl
{
    public partial class RuleControl : UserControl
    {
        public BindingList<RuleItem> ItemsSource { get; set; }

        public RuleControl()
        {
            InitializeComponent();

            DataContext = this;
            ItemsSource = new BindingList<RuleItem>();

            ItemsSource.Add(new RuleItem { Id = 1, Name = "jhfhjgf" });
            ItemsSource.Add(new RuleItem { Id = 2, Name = "aaa" });
            ItemsSource.Add(new RuleItem { Id = 3, Name = "jhfaaarhjgf" });

            lv.ItemsSource = ItemsSource;
        }

        private void lv_OnSelectionChanged(IEnumerable<int> selectedIndies)
        {
            Debug.WriteLine("fjghfjhfg");
        }
    }
}
