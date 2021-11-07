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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BatchRename.Themes.CustomControl
{
    /// <summary>
    /// Interaction logic for WindowCommandButtons.xaml
    /// </summary>
    public partial class WindowCommandButtons : UserControl
    {
        public static readonly DependencyProperty ShowMinimizeProperty =
            DependencyProperty.Register(
                "ShowMinimizeBackground",
                typeof(Boolean),
                typeof(StackPanel),
                new PropertyMetadata(true)
            );

        public static readonly DependencyProperty ShowRestoreProperty =
          DependencyProperty.Register(
              "ShowRestoreBackground",
              typeof(Boolean),
              typeof(StackPanel),
              new PropertyMetadata(true)
          );

        public Boolean ShowMinimize
        {
            get => (Boolean)GetValue(ShowMinimizeProperty);
            set => SetValue(ShowMinimizeProperty, value);
        }

        public Boolean ShowRestore
        {
            get => (Boolean)GetValue(ShowRestoreProperty);
            set => SetValue(ShowRestoreProperty, value);
        }

        public WindowCommandButtons()
        {
            InitializeComponent();
        }

        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);

            if (window.WindowState == WindowState.Maximized)
                SystemCommands.RestoreWindow(window);

            if (window.WindowState == WindowState.Normal)
                SystemCommands.MaximizeWindow(window);
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            SystemCommands.MinimizeWindow(window);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            SystemCommands.CloseWindow(window);
        }
    }
}