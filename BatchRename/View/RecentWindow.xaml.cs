using BatchRename.Commands;
using BatchRename.Lib;
using BatchRename.Model;
using BatchRename.Themes.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace BatchRename.View
{
    public partial class RecentWindow : Window, INotifyPropertyChanged
    {
        public BindingList<RecentFileItem> Files { get; set; }
        public RecentFileItem SelectedItem { get; set; }

        public ICommand SelectCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DeleteRecentCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private PluginManager _pluginManager { get; set; }

        public RecentWindow(PluginManager pluginManager)
        {
            InitializeComponent();

            _pluginManager = pluginManager;

            SelectCommand = new RelayCommand<RecentFileItem>(
                (_) => true,
                (selectedFile) =>
                {
                    HandleRecentFileSelected(selectedFile);
                }
            );

            NewCommand = new RelayCommand<object>(
                (_) => true,
                (_) =>
                {
                    ICommand command = new NewCommand(_pluginManager, () => Close());
                    command.Execute(null);
                }
            );

            OpenCommand = new RelayCommand<object>(
                (_) => true,
                (_) =>
                {
                    ICommand command = new OpenCommand(_pluginManager, () => Close());
                    command.Execute(null);
                }
            );

            DeleteRecentCommand = new RelayCommand<RecentFileItem>(
                (_) => true,
                (f) =>
                {
                    Files.Remove(f);
                    RecentFiles.Shared.RemoveRecent(f.Path);
                });

            Files = new BindingList<RecentFileItem>(RecentFiles.Shared.GetRecentFiles().Items);
            DataContext = this;
        }

        public void HandleRecentFileSelected(RecentFileItem selectedFile)
        {
            SelectedItem = selectedFile;

            string path = selectedFile.Path;

            if (!File.Exists(path))
            {
                var result = MessageBox.Show(
                    "Project is deleted. Do you want to delete it?",
                    "Project Not Found",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question,
                    MessageBoxResult.Yes
                );

                if (result == MessageBoxResult.Yes)
                {
                    DeleteRecentCommand.Execute(SelectedItem);
                }

                SelectedItem = null;
                return;
            }

            if (!(Path.GetExtension(path) != "bare"))
            {
                MessageBox.Show("Invalid file format");

                SelectedItem = null;
                return;
            }

            MainWindow mainWindow = new MainWindow(_pluginManager);
            mainWindow.LoadFrom(path);
            mainWindow.Show();

            Close();
        }
    }
}