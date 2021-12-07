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
    /// <summary>
    /// Interaction logic for RuleAction.xaml
    /// </summary>
    public partial class RuleAction : UserControl, INotifyPropertyChanged
    {
        private Window window;
        public Window Window
        {
            get => window;
            set
            {
                window = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Window"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RuleAction()
        {
            InitializeComponent();

            window = Window.GetWindow(this);
            DataContext = this;
        }
    }
}
