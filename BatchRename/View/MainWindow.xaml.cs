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
using BatchRename.Lib;
using PluginContract;
using BatchRename.ViewModel;
using Microsoft.WindowsAPICodePack.Dialogs;
using BatchRename.Commands;

namespace BatchRename
{
    public partial class MainWindow : Window
    {
        public BindingList<RulePickedViewModel> PickedRules { get; set; }
        public BindingList<NodeConvertViewModel> ConvertNodes { get; set; }

        public ICommand NewCommand { get; set; }
        public ICommand ConvertCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand LoadProjectCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand SaveOrSaveAsCommand { get; set; }
        public ICommand ImportCommand { get; set; }
        public ICommand ExportCommand { get; set; }

        private PluginManager _pluginManager { get; set; }
        private Store _store { get; set; }

        private BackupService<ProjectStore> _backupService { get; set; }
        private RecentFileService _recentFileService { get; set; }

        private SaveService<ProjectStore> _saveService { get; set; }
        private LoadService<ProjectStore> _loadService { get; set; }
        private AutoSaveService<ProjectStore> _autoSaveService { get; set; }

        private IPersister<ProjectStore> _persister { get; set; }

        public MainWindow(PluginManager pluginManager)
        {
            InitializeComponent();

            _pluginManager = pluginManager;
            _store = new Store();

            DataContext = this;

            InitializeServices();
            InitializeCommands();
            RegisterStoreChanged();

            PickedRules = new BindingList<RulePickedViewModel>();
            ConvertNodes = new BindingList<NodeConvertViewModel>();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var window = (Window)sender;

            _store.UpdateMainWindowPosition(new WindowPosition
            {
                Top = window.Top,
                Left = window.Left,
                Width = e.NewSize.Width,
                Height = e.NewSize.Height
            });
        }
    }

    /* Initialize */
    public partial class MainWindow
    {
        private void InitializeCommands()
        {
            NewCommand = new NewCommand(_pluginManager);
            ConvertCommand = new ConvertCommand(_store, _pluginManager);
            OpenCommand = new OpenCommand(_pluginManager);
            LoadProjectCommand = new LoadProjectCommand(_store, _loadService);
            SaveOrSaveAsCommand = new SaveOrSaveAsCommand(_store, _saveService);
            SaveAsCommand = new SaveAsCommand(_store, _saveService);
        }

        private void InitializeServices()
        {
            var _autoSaveConfig = new AutoSaveConfig
            {
                AutoSave = true,
                AutoSaveInterval = 30
            };

            var _backupConfig = new BackupConfig
            {
                Directory = Environment.GetEnvironmentVariable("BackupFilesPath"),
                BackupInterval = 120,
                Extension = "brup",
            };

            _persister = new JsonPersister<ProjectStore>();
            _saveService = new SaveService<ProjectStore>(_persister);
            _loadService = new LoadService<ProjectStore>(_persister);

            _autoSaveService = new AutoSaveService<ProjectStore>(_autoSaveConfig, _persister);
            _autoSaveService.GetSavePath = () => _store.CurrentProjectPath;
            _autoSaveService.GetSaveData = () => new ProjectStore()
            {

            };

            _backupService = new BackupService<ProjectStore>(_backupConfig, _persister);
            _backupService.GetBackupData = () => new ProjectStore();
            _backupService.GetBackupPath = () => _store.CurrentProjectPath;
        }

        private void RegisterStoreChanged()
        {
            _store.OnStoreChanged += OnStore_Changed;
            _store.OnStoreLoaded += OnStore_Loaded_RulePicked;
            _store.OnStoreLoaded += OnStore_Loaded_NodeConvert;
            _store.OnRulePickedCreated += OnRulePicked_Created;
            _store.OnRulePickedDeleted += OnRulePicked_Deleted;
            _store.OnRulePickedUpdated += OnRulePicked_Updated;
            _store.OnNodeConvertCreated += OnNodeConvert_Created;
        }

        private void OnStore_Changed()
        {
            _store.HasContentUnsaved = true;
            _store.IsBlankProject = false;
        }
    }

    /* HANDLE Rule control panel: Store event */
    public partial class MainWindow
    {
        private void OnStore_Loaded_RulePicked()
        {
            PickedRules.Clear();
            _store.GetAllPickedRule().ForEach(rule =>
            {
                RulePickedViewModel newViewModel = CreateRulePickedViewModel(rule);
                PickedRules.Add(newViewModel);
            });
        }

        private void OnRulePicked_Created(RulePickedModel ruleModel)
        {
            RulePickedViewModel newViewModel = CreateRulePickedViewModel(ruleModel);
            PickedRules.Add(newViewModel);
        }

        private void OnRulePicked_Deleted(string id)
        {
            var ruleViewModel = PickedRules.First(rule => rule.Id == id);

            if (ruleViewModel == null)
                return;

            PickedRules.Remove(ruleViewModel);
        }

        private void OnRulePicked_Updated(RulePickedModel ruleModel)
        {
            RulePickedViewModel ruleViewModel = PickedRules.First(rule => rule.Id == ruleModel.Id);

            if (ruleViewModel == null)
                return;

            string ruleName = _pluginManager.GetRuleName(ruleModel.RuleId);
            IRenameRule rule = _pluginManager.CreateRule(ruleModel.RuleId);
            rule.SetParameter(ruleModel.Paramter);

            ruleViewModel.RuleName = ruleName;
            ruleViewModel.Statement = rule.GetStatement();
        }

        private RulePickedViewModel CreateRulePickedViewModel(RulePickedModel ruleModel)
        {
            string ruleName = _pluginManager.GetRuleName(ruleModel.RuleId);

            IRenameRule rule = _pluginManager.CreateRule(ruleModel.RuleId);
            rule.SetParameter(ruleModel.Paramter);

            var newRuleViewModel = new RulePickedViewModel()
            {
                Id = ruleModel.Id,
                IsMarked = ruleModel.IsMarked,
                RuleName = ruleName,
                Statement = rule.GetStatement()
            };

            return newRuleViewModel;
        }
    }

    /* HANDLE Rule control panel: Event click*/
    public partial class MainWindow
    {
        private void RuleControl_OnAddClick(object sender, RoutedEventArgs e)
        {
            RuleWindow ruleWindow = new RuleWindow(_pluginManager, _store);
            ruleWindow.ShowDialog();
        }

        private void RuleControl_OnRemoveClick(object sender, RoutedEventArgs e)
        {
            if (ruleControl.SelectedIds == null)
                return;

            foreach (var id in ruleControl.SelectedIds)
                _store.DeletePickedRule(id);
        }

        private void ruleControl_OnUpClick(object sender, RoutedEventArgs e)
        {
            // TODO: move rule up
        }

        private void ruleControl_OnDownClick(object sender, RoutedEventArgs e)
        {
            // TODO: move rule down
        }

        private void ruleControl_OnRowDoubleClick(string id)
        {
            // TODO: Handle Edit Rult (Show RuleWindow)
        }
    }

    /* Load from exists project */
    public partial class MainWindow
    {
        public void LoadFrom(string path)
        {
            LoadProjectCommand.Execute(path);
            _store.IsBlankProject = false;
            _autoSaveService.EnableAutoSave();
        }
    }

    /* HANDLE Top Menu: Open/Save/Load/Convert click*/
    public partial class MainWindow
    {
        private void TopMenu_OnNewClick(object sender, RoutedEventArgs e)
        {
            NewCommand.Execute(null);
        }

        private void TopMenu_OnOpenClick(object sender, RoutedEventArgs e)
        {
            OpenCommand.Execute(null);
        }

        private void TopMenu_OnSaveClick(object sender, RoutedEventArgs e)
        {
            SaveOrSaveAsCommand.Execute(null);
        }

        private void TopMenu_OnStartClick(object sender, RoutedEventArgs e)
        {
            ConvertCommand.Execute(null);
        }

        private void TopMenu_OnSaveAsClick(object sender, RoutedEventArgs e)
        {
            SaveAsCommand.Execute(null);
        }

        private void TopMenu_OnImportPresetClick(object sender, RoutedEventArgs e)
        {
            ImportCommand.Execute(null);
            // TODO Implement import preset command
        }

        private void TopMenu_OnExportPresetClick(object sender, RoutedEventArgs e)
        {
            ExportCommand.Execute(null);
            // TODO Implement Export preset command
        }
    }

    /* HANDLE File Control Panel */
    public partial class MainWindow
    {
        private static List<string> _list = new List<string>();
        DropFilePanel dragdropPanel = new DropFilePanel();

        private void OnStore_Loaded_NodeConvert()
        {
            ConvertNodes.Clear();
            _store.GetAllNodeConverts().ForEach(nodeModel =>
            {
                NodeConvertViewModel nodeViewModel = CreateNodeConvertViewModel(nodeModel);
                ConvertNodes.Add(nodeViewModel);
            });
        }

        private void OnNodeConvert_Created(NodeConvertModel nodeModel)
        {
            NodeConvertViewModel newNodeViewModel = CreateNodeConvertViewModel(nodeModel);
            ConvertNodes.Add(newNodeViewModel);
        }

        private void FilesControl_OnAddFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {

                foreach (var path in openFileDialog.FileNames)
                {
                    if (!_list.Contains(path))
                    {
                        _list.Add(path);
                        string extention = Path.GetExtension(path);
                        string filename = Path.GetFileName(path);
                        DateTime creation = File.GetCreationTime(path);
                        string size = extention.Length == 0 ? string.Empty : new System.IO.FileInfo(path).Length.ToString();
                        Node node = new Node()
                        {
                            Path = path,
                            Extension = extention,
                            Name = Name,
                            CreatedDate = creation,
                            Size = size
                        };

                        NodeConvertModel nodeConvert = new NodeConvertModel()
                        {
                            Node = node,
                            ConvertStatus = ConvertStatus.PENDING,
                            IsMarked = true,
                        };

                        _store.CreateNodeConvert(nodeConvert);
                    }
                }
            }

        }

        private void filesControl_OnAddFolderClick(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // TODO
            }
        }

        private void handleFolder(string path)
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                if (!_list.Contains(fileName))
                    _list.Add(fileName);
            }
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(path);
            foreach (string subdirectory in subdirectoryEntries)
                handleFolder(subdirectory);
        }


        private void DragDrop_Files(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                List<string> lastFileList = new List<string>(_list);

                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var file in files)
                {
                    if (!_list.Contains(file))
                    {
                        if (File.Exists(file))
                        {
                            // This path is a file
                            if (!_list.Contains(file))
                                _list.Add(file);
                        }
                        else if (Directory.Exists(file))
                        {
                            // This path is a directory
                            handleFolder(file);
                        }
                    }
                }


                foreach (var path in _list)
                {
                    if (!lastFileList.Contains(path))
                    {
                        string extention = Path.GetExtension(path);
                        string filename = Path.GetFileName(path);
                        DateTime creation = File.GetCreationTime(path);
                        string size = extention.Length == 0 ? string.Empty : new System.IO.FileInfo(path).Length.ToString();
                        Node node = new Node()
                        {
                            Path = path,
                            Extension = extention,
                            Name = Name,
                            CreatedDate = creation,
                            Size = size
                        };

                        NodeConvertModel nodeConvert = new NodeConvertModel()
                        {
                            //TODO: Is there anything more ?
                            Node = node
                        };

                        //TODO: Does it need to invoke anything ?
                        _store.CreateNodeConvert(nodeConvert);
                    }
                }
            }
            dragdropPanel.Drop -= DragDrop_Files;
            FilePanel_Grid.Children.Remove(dragdropPanel);
        }

        private void DragEnter_Show(object sender, DragEventArgs e)
        {
            if (FilePanel_Grid.Children.Count < 3)
            {
                dragdropPanel.Drop += DragDrop_Files;
                FilePanel_Grid.Children.Add(dragdropPanel);
            }
        }

        private void DragLeave_Hide(object sender, DragEventArgs e)
        {

            if (FilePanel_Grid.Children.Count == 3)
            {
                HitTestResult result = VisualTreeHelper.HitTest(FilePanel_Grid, e.GetPosition(FilePanel_Grid));
                if (result == null)
                {
                    dragdropPanel.Drop -= DragDrop_Files;
                    FilePanel_Grid.Children.Remove(dragdropPanel);
                }
            }
        }

        private NodeConvertViewModel CreateNodeConvertViewModel(NodeConvertModel nodeModel)
        {
            NodeConvertModel newNode = nodeModel.Clone();

            NodeConvertViewModel newNodeViewModel = new NodeConvertViewModel()
            {
                ConvertStatus = newNode.ConvertStatus,
                IsMarked = newNode.IsMarked,
                Id = newNode.Id,
                Node = new NodeViewModel()
                {
                    CreatedDate = newNode.Node.CreatedDate,
                    Name = newNode.Node.Name,
                    Size = newNode.Node.Size,
                    Extension = newNode.Node.Extension,
                    Path = newNode.Node.Path
                    //TODO: Set output path
                }
            };

            return newNodeViewModel;
        }
    }
}