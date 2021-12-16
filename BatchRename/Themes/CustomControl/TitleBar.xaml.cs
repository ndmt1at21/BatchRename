using System.Windows;
using System.Windows.Controls;

namespace BatchRename.Themes.CustomControl
{
    public partial class TitleBar : UserControl
    {
        public event RoutedEventHandler OnOpenClick;
        public event RoutedEventHandler OnSaveClick;
        public event RoutedEventHandler OnNewClick;
        public event RoutedEventHandler OnStartClick;

        public TitleBar()
        {
            InitializeComponent();
        }

        private void topMenu_OnNewClick(object sender, RoutedEventArgs e)
        {
            OnNewClick?.Invoke(sender, e);
        }

        private void topMenu_OnOpenClick(object sender, RoutedEventArgs e)
        {
            OnOpenClick?.Invoke(sender, e);
        }

        private void topMenu_OnStartClick(object sender, RoutedEventArgs e)
        {
            OnStartClick?.Invoke(sender, e);
        }

        private void topMenu_OnSaveClick(object sender, RoutedEventArgs e)
        {
            OnSaveClick?.Invoke(sender, e);
        }
    }
}