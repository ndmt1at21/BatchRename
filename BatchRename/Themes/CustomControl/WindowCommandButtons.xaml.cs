using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BatchRename.Themes.CustomControl
{
    /// <summary>
    /// Interaction logic for WindowCommandButtons.xaml
    /// </summary>
    public partial class WindowCommandButtons : UserControl
    {
        public static readonly DependencyProperty ExitCommandProperty =
            DependencyProperty.Register(
                "ExitCommand",
                typeof(ICommand),
                typeof(WindowCommandButtons),
                new PropertyMetadata(null)
            );

        public ICommand ExitCommand
        {
            get => (ICommand)GetValue(ExitCommandProperty);
            set => SetValue(ExitCommandProperty, value);
        }

        public static readonly DependencyProperty ShowMinimizeProperty =
            DependencyProperty.Register(
                "ShowMinimizeBackground",
                typeof(Boolean),
                typeof(WindowCommandButtons),
                new PropertyMetadata(true)
            );

        public static readonly DependencyProperty ShowRestoreProperty =
          DependencyProperty.Register(
              "ShowRestoreBackground",
              typeof(Boolean),
              typeof(WindowCommandButtons),
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

        private void BRButton_Click(object sender, RoutedEventArgs e)
        {
            if (ExitCommand == null)
            {
                Window window = Window.GetWindow(this);
                SystemCommands.CloseWindow(window);
            }
        }
    }
}