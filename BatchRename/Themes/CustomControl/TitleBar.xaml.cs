using System.Diagnostics;
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

        public event RoutedEventHandler OnSaveAsClick;
        public event RoutedEventHandler OnImportPresetClick;
        public event RoutedEventHandler OnExportPresetClick;
        public event RoutedEventHandler OnExitClick;

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

        private void AppMenu_OnExitClick(object sender, RoutedEventArgs e)
        {
            OnExitClick?.Invoke(sender, e);
        }

        private void AppMenu_OnOpenProjectClick(object sender, RoutedEventArgs e)
        {
            OnOpenClick?.Invoke(sender, e);
        }

        private void AppMenu_OnSaveAsClick(object sender, RoutedEventArgs e)
        {
            OnSaveAsClick?.Invoke(sender, e);
        }

        private void AppMenu_OnSaveProjectClick(object sender, RoutedEventArgs e)
        {
            OnSaveClick?.Invoke(sender, e);
        }

        private void AppMenu_OnImportPresetClick(object sender, RoutedEventArgs e)
        {
            OnImportPresetClick?.Invoke(sender, e);
        }

        private void AppMenu_OnExportPresetClick(object sender, RoutedEventArgs e)
        {
            OnExportPresetClick?.Invoke(sender, e);
        }

        private void AppMenu_OnNewProjectClick(object sender, RoutedEventArgs e)
        {
            OnNewClick?.Invoke(sender, e);
        }
    }
}