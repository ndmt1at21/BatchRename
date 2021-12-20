using BatchRename.Lib;
using System;
using System.Collections.Generic;
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
    public partial class AppMenu : UserControl
    {
        public event RoutedEventHandler OnNewProjectClick;
        public event RoutedEventHandler OnOpenProjectClick;
        public event RoutedEventHandler OnSaveProjectClick;
        public event RoutedEventHandler OnSaveAsClick;
        public event RoutedEventHandler OnExitClick;

        public event RoutedEventHandler OnImportPresetClick;
        public event RoutedEventHandler OnExportPresetClick;

        public AppMenu()
        {
            InitializeComponent();
        }

        private void btnNewProject_Click(object sender, RoutedEventArgs e)
        {
            OnNewProjectClick?.Invoke(sender, e);
        }

        private void btnOpenProject_Click(object sender, RoutedEventArgs e)
        {
            OnOpenProjectClick?.Invoke(sender, e);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            OnSaveProjectClick?.Invoke(sender, e);
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            OnSaveAsClick?.Invoke(sender, e);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            OnExitClick?.Invoke(sender, e);
        }

        private void btnImportPreset_Click(object sender, RoutedEventArgs e)
        {
            OnImportPresetClick?.Invoke(sender, e);
        }

        private void btnExportPreset_Click(object sender, RoutedEventArgs e)
        {
            OnExportPresetClick?.Invoke(sender, e);
        }
    }

    public partial class AppMenu
    {
        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Import_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Export_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.WriteLine("new Exceuta");
            OnNewProjectClick?.Invoke(sender, e);
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OnOpenProjectClick?.Invoke(sender, e);
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OnSaveProjectClick?.Invoke(sender, e);
        }

        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OnSaveAsClick?.Invoke(sender, e);
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OnExitClick?.Invoke(sender, e);
        }

        private void Import_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OnImportPresetClick?.Invoke(sender, e);
        }

        private void Export_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OnExportPresetClick?.Invoke(sender, e);
        }
    }
}
