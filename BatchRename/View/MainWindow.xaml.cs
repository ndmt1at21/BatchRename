using BatchRename.Lib;
using BatchRename.Model;
using BatchRename.Themes.CustomControl;
using BatchRename.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PluginManager _pluginManager { get; set; }
        private Store _store { get; set; }
        private SaveLoadService<ProjectStore> _saveLoadService { get; set; }
        private BackupService<ProjectStore> _backupService { get; set; }
        private RecentFileService _recentFileService { get; set; }

        public MainWindow(PluginManager pluginManager, RecentFileService recentFileService)
        {
            InitializeComponent();

            _pluginManager = pluginManager;
            _recentFileService = recentFileService;
            _store = new Store();

            _store.OnStoreChanged += OnStore_Changed;

            var _saveLoadConfig = new SaveLoadConfig
            {
                AutoSave = true,
                AutoSaveInterval = 500
            };

            var _backupConfig = new BackupConfig
            {
                Directory = Environment.GetEnvironmentVariable("BackupFilesPath"),
                BackupInterval = 500,
                Extension = "brup",
            };

            _saveLoadService = new SaveLoadService<ProjectStore>(_saveLoadConfig);
            _backupService = new BackupService<ProjectStore>(_backupConfig);
        }

        public void OnStore_Changed()
        {
            _saveLoadService.HasSaved = false;
        }

        private void Container_DragEnter(object sender, DragEventArgs e)
        {
            //TODO: Show drag drop panel
        }

        private void Container_DragLeave(object sender, DragEventArgs e)
        {
            //TODO: Hid drag and drop panel

        }

        private void FilesControl_OnAddFileClick(object sender, RoutedEventArgs e)
        {

        }
    }

    // HANDLE RuleControl
    public partial class MainWindow
    {
        private void RuleControl_OnAddClick(object sender, RoutedEventArgs e)
        {
            string[] pluginIds = _pluginManager.GetPluginIDs();

            List<RuleComponent> ruleComponents = new List<RuleComponent>();

            foreach (string id in pluginIds)
            {
                ruleComponents.Add(
                    new RuleComponent
                    {
                        Id = id,
                        Name = _pluginManager.GetRuleName(id),
                        Component = _pluginManager.CreateRuleComponent(id)
                    });
            }

            RuleWindow ruleWindow = new RuleWindow(ruleComponents, _store);
            ruleWindow.ShowDialog();
        }

        private void RuleControl_OnRemoveClick(object sender, RoutedEventArgs e)
        {
            // TODO: Remove
        }
    }

    // HANDLE Open/Save/Load
    public partial class MainWindow
    {
        public void Open(string path)
        {
            LoadFrom(path);
        }

        public void Save()
        {

        }

        public void SaveAs()
        {

        }

        public void LoadFrom(string projectPath)
        {
            LoadProjectToStore(projectPath);
        }

        private void LoadProjectToStore(string path)
        {
            if (!File.Exists(path))
                return;

            _saveLoadService.Path = path;

            ProjectStore projectStore = _saveLoadService.Load();

            _store.MainWindowPosition = projectStore.MainWindowPosition;
            _store.DialogSelectRulePosition = projectStore.DialogSelectRulePosition;
            _store.PickedRules = projectStore.PickedRules;
            _store.EditingRules = projectStore.EditingRules;
            _store.ConvertNodes = projectStore.ConvertNodes;
        }

        private void TopMenu_OnNewClick(object sender, RoutedEventArgs e)
        {
            if (!_saveLoadService.HasSaved)
                MessageBox.Show("Ban co muon luu khong");
        }

        private void TopMenu_OnOpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bare files (*.bare) | *.bare | All files (*.*) | *.*";

            if (openFileDialog.ShowDialog() == true)
            {

            }
        }

        private void TopMenu_OnSaveClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {

            }
        }

        private void TopMenu_OnStartClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start Convert");
        }
    }
}