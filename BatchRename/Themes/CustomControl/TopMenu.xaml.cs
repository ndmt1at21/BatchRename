using System;
using System.Windows;
using System.Windows.Controls;

namespace BatchRename.Themes.CustomControl
{
    public delegate void HandlerConvertClick();

    public partial class TopMenu : UserControl
    {
        public event RoutedEventHandler OnOpenClick;
        public event RoutedEventHandler OnSaveClick;
        public event RoutedEventHandler OnNewClick;
        public event RoutedEventHandler OnStartClick;

        public TopMenu()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            OnNewClick?.Invoke(sender, e);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OnOpenClick?.Invoke(sender, e);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            OnSaveClick?.Invoke(sender, e);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            OnStartClick?.Invoke(sender, e);
        }
    }
}