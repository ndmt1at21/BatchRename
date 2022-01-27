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
using BatchRename.Commands.Rules;
using BatchRename.Commands.Files;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace BatchRename
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static int ProjectNumber { get; set; } = 0;
        public string CurrentProjectName { get; set; }

        public ObservableCollection<RulePickedViewModel> PickedRules { get; set; }
        public ObservableCollection<NodeConvertViewModel> ConvertNodes { get; set; }

        public ICommand NewCommand { get; set; }
        public ICommand ConvertCommand { get; set; }
        public ICommand PreviewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand LoadProjectCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand SaveOrSaveAsCommand { get; set; }
        public ICommand ImportCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public ICommand AddRuleCommand { get; set; }
        public ICommand RemoveRuleCommand { get; set; }

        public ICommand AddFileCommand { get; set; }
        public ICommand AddFolderCommand { get; set; }
        public ICommand ChooseOutputCommand { get; set; }
        public ICommand RemoveFileCommand { get; set; }
        public ICommand DropFileCommand { get; set; }

        private PluginManager _pluginManager { get; set; }
        private Store _store { get; set; }

        private BackupService<ProjectStore> _backupService { get; set; }
        private SaveService<ProjectStore> _saveProjectService { get; set; }
        private LoadService<ProjectStore> _loadProjectService { get; set; }
        private AutoSaveService<ProjectStore> _autoSaveService { get; set; }

        private SaveService<RulePreset> _savePresetService { get; set; }
        private LoadService<RulePreset> _loadPresetService { get; set; }

        private IPersister<ProjectStore> _persisterProject { get; set; }
        private IPersister<RulePreset> _persisterPreset { get; set; }

        public MainWindow(PluginManager pluginManager)
        {
            InitializeComponent();

            _pluginManager = pluginManager;

            DataContext = this;
            InitializeStore();
            InitializeServices();
            InitializeCommands();

            PickedRules = new ObservableCollection<RulePickedViewModel>();
            ConvertNodes = new ObservableCollection<NodeConvertViewModel>();

            dragdropPanel.Drop += DragDrop_Files;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var window = (Window)sender;

            _store.UpdateMainWindowPosition(new WindowPosition
            {
                Top = window.Top,
                Left = window.Left,
                Width = window.ActualWidth,
                Height = window.ActualHeight
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }

    /* Initialize */
    public partial class MainWindow
    {
        private void InitializeStore()
        {
            _store = new Store();
            RegisterStoreChanged();

            _store.CurrentProjectPath = $"brename{ProjectNumber}";
        }

        private void InitializeCommands()
        {
            NewCommand = new NewCommand(_pluginManager);
            ConvertCommand = new ConvertCommand(_store, _pluginManager);
            PreviewCommand = new PreviewCommand(_store, _pluginManager);
            OpenCommand = new OpenCommand(_pluginManager);
            LoadProjectCommand = new LoadProjectCommand(_store, _loadProjectService);
            SaveOrSaveAsCommand = new SaveOrSaveAsCommand(_store, _saveProjectService);
            SaveAsCommand = new SaveAsCommand(_store, _saveProjectService);
            ImportCommand = new ImportCommand(_store, _loadPresetService);
            ExportCommand = new ExportCommand(_store, _savePresetService);
            ExitCommand = new ExitCommand(_store, this);

            AddRuleCommand = new AddRuleCommand(_store, _pluginManager);
            RemoveRuleCommand = new RemoveRuleCommand(_store);

            AddFileCommand = new AddFileCommand(_store, _listFilesAlreadyAdded);
            AddFolderCommand = new AddFolderCommand(_store, _listFilesAlreadyAdded);
            DropFileCommand = new DropFileCommand(_store, _listFilesAlreadyAdded);
            ChooseOutputCommand = new ChooseOutputCommand(_store);
            RemoveFileCommand = new RemoveFileCommand(_store);
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
                BackupInterval = 10,
                Extension = "brup",
            };

            _persisterProject = new JsonPersister<ProjectStore>();
            _persisterPreset = new JsonPersister<RulePreset>();

            _saveProjectService = new SaveService<ProjectStore>(_persisterProject);
            _loadProjectService = new LoadService<ProjectStore>(_persisterProject);

            _savePresetService = new SaveService<RulePreset>(_persisterPreset);
            _loadPresetService = new LoadService<RulePreset>(_persisterPreset);

            _autoSaveService = new AutoSaveService<ProjectStore>(_autoSaveConfig, _persisterProject);
            _autoSaveService.GetSavePath = () => _store.CurrentProjectPath;
            _autoSaveService.GetSaveData = () => ProjectStore.FromStore(_store);

            _backupService = new BackupService<ProjectStore>(_backupConfig, _persisterProject);
            _backupService.GetBackupData = () => new ProjectStore();
            _backupService.GetBackupPath = () => _store.CurrentProjectPath;
            _backupService.StartBackup();
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
            _store.OnNodeConvertUpdated += OnNodeConvert_Updated;
            _store.OnNodeConvertDeleted += OnNodeConvert_Deleted;
            _store.OnProjectPathChanged += OnProjectPath_Changed;
            _store.OnMainWindowPositionUpdated += OnMainWindowPosition_Updated;

            _store.OnOutputPathChanged += OnOutputPath_Changed;
        }

        private void OnProjectPath_Changed()
        {
            CurrentProjectName = Path.GetFileName(_store.CurrentProjectPath);
        }

        private void OnMainWindowPosition_Updated(WindowPosition position)
        {
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
                RuleId = ruleModel.RuleId,
                IsMarked = ruleModel.IsMarked,
                RuleName = ruleName,
                Statement = rule.GetStatement(),
            };

            return newRuleViewModel;
        }

        private void ruleControl_OnMarkChanged(string markId)
        {
            var rule = _store.PickedRules[markId];
            RulePickedUpdateModel updateRule = new RulePickedUpdateModel
            {
                Id = rule.Id,
                IsMarked = !rule.IsMarked
            };
            _store.UpdatePickedRule(updateRule);
        }
    }

    /* HANDLE Rule control panel: Event click*/
    public partial class MainWindow
    {
        private void RuleControl_OnAddClick(object sender, RoutedEventArgs e)
        {
            AddRuleCommand.Execute(null);
        }

        private void RuleControl_OnRemoveClick(object sender, RoutedEventArgs e)
        {
            List<string> selectedIds = new List<string>();

            foreach (var item in ruleControl.SelectedItems)
            {
                var rule = (RulePickedViewModel)item;
                selectedIds.Add(rule.Id);
            }

            RemoveRuleCommand.Execute(selectedIds);
        }

        private void ruleControl_OnUpClick(object sender, RoutedEventArgs e)
        {
            if (ruleControl.SelectedItems.Count == 1)
            {
                for (int i = 1; i < PickedRules.Count; i++)
                {
                    if (ruleControl.SelectedItems[0] == PickedRules[i])
                    {
                        ruleControl.SelectedItems.Clear();
                        ruleControl.SelectedItems.Add(PickedRules[i - 1]);
                    }
                }
            }
        }

        private void ruleControl_OnDownClick(object sender, RoutedEventArgs e)
        {
            // TODO: move rule down
            if (ruleControl.SelectedItems.Count == 1)
            {
                for (int i = PickedRules.Count - 2; i >= 0; i--)
                {
                    if (ruleControl.SelectedItems[0] == PickedRules[i])
                    {
                        ruleControl.SelectedItems.Clear();
                        ruleControl.SelectedItems.Add(PickedRules[i + 1]);
                    }
                }
            }
        }

        private void ruleControl_OnRowDoubleClick(string id)
        {
            RuleWindow ruleWindow = new RuleWindow(_pluginManager, _store, id);
            ruleWindow.ShowDialog();
        }
    }

    /* Load from exists project */
    public partial class MainWindow
    {
        public void LoadFrom(string path)
        {
            LoadProjectCommand.Execute(path);
            _autoSaveService.EnableAutoSave();

            RecentFiles.Shared.AddRecent(_store.CurrentProjectPath);
        }
    }

    /* HANDLE File Control Panel */
    public partial class MainWindow
    {
        private static List<string> _listFilesAlreadyAdded = new List<string>();

        public bool IsDraging { get; set; } = false;

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

        private void OnNodeConvert_Updated(NodeConvertModel nodeModel)
        {
            NodeConvertViewModel nodeViewModel = ConvertNodes.First(node => node.Id == nodeModel.Id);

            nodeViewModel.ConvertStatus = nodeModel.ConvertStatus;
            nodeViewModel.IsMarked = nodeModel.IsMarked;
            nodeViewModel.NewName = nodeModel.NewName;
            nodeViewModel.Error = nodeModel.Error;
        }

        private void OnOutputPath_Changed(string outputPath)
        {
            foreach (var node in ConvertNodes)
            {
                node.OutputPath = outputPath;
            }
        }

        private void OnNodeConvert_Deleted(string id)
        {
            var nodeViewModel = ConvertNodes.First(node => node.Id == id);

            if (nodeViewModel == null)
                return;

            _listFilesAlreadyAdded.Remove(nodeViewModel.Node.Path);
            ConvertNodes.Remove(nodeViewModel);
        }

        private void FilesControl_OnAddFileClick(object sender, RoutedEventArgs e)
        {
            AddFileCommand.Execute(null);
        }

        private void filesControl_OnAddFolderClick(object sender, RoutedEventArgs e)
        {
            AddFolderCommand.Execute(null);
        }

        private void filesControl_OnRemoveFileClick(object sender, RoutedEventArgs e)
        {
            List<string> selectedIds = new List<string>();

            foreach (var item in filesControl.SelectedItems)
            {
                var node = (NodeConvertViewModel)item;
                selectedIds.Add(node.Id);
            }

            RemoveFileCommand.Execute(selectedIds);
        }

        private void filesControl_OnMarkChanged(string markId)
        {
            var node = _store.GetNodeConvert(markId);
            node.IsMarked = !node.IsMarked;
            _store.UpdateNodeConvert(node);
        }

        private void DragDrop_Files(object sender, DragEventArgs e)
        {
            DropFileCommand.Execute(e);
            IsDraging = false;
            //dragdropPanel.Visibility = Visibility.Hidden;
        }

        private void DragEnter_Show(object sender, DragEventArgs e)
        {
            // dragdropPanel.Visibility = Visibility.Visible;
            IsDraging = true;
        }

        private void DragLeave_Hide(object sender, DragEventArgs e)
        {
            HitTestResult result = VisualTreeHelper.HitTest(FilePanel_Grid, e.GetPosition(FilePanel_Grid));
            if (result == null)
            {
                IsDraging = false;
                // dragdropPanel.Visibility = Visibility.Hidden;
            }
        }

        private void DragLeave_MouseMove_Hide(object sender, MouseEventArgs e)
        {
            HitTestResult result = VisualTreeHelper.HitTest(FilePanel_Grid, e.GetPosition(FilePanel_Grid));
            if (result == null)
            {
                IsDraging = false;
                // dragdropPanel.Visibility = Visibility.Hidden;
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
                OutputPath = _store.OutputPath,
                NewName = newNode.NewName,
                Error = newNode.Error,
                Node = new NodeViewModel()
                {
                    CreatedDate = newNode.Node.CreatedDate,
                    Name = newNode.Node.Name + newNode.Node.Extension,
                    Size = newNode.Node.Size,
                    Path = newNode.Node.Path
                }
            };

            return newNodeViewModel;
        }
    }
}