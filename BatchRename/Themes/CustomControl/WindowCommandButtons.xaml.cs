using System;
using System.Windows;
using System.Windows.Controls;

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