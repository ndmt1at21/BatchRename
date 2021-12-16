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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BatchRename.Themes.CustomControl
{
    public partial class RuleAction : UserControl
    {
        public event RoutedEventHandler OnDownClick;
        public event RoutedEventHandler OnUpClick;
        public event RoutedEventHandler OnAddClick;
        public event RoutedEventHandler OnRemoveClick;

        public RuleAction()
        {
            InitializeComponent();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            OnDownClick?.Invoke(sender, e);
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            OnUpClick?.Invoke(sender, e);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            OnRemoveClick?.Invoke(sender, e);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OnAddClick?.Invoke(sender, e);
        }
    }
}
