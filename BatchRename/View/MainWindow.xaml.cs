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
using BatchRename.Lib;
using PluginContract;
using BatchRename.ViewModel;

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<RulePickedViewModel> PickedRules { get; set; }

        private PluginManager _pluginManager { get; set; }
        private Store _store { get; set; }
        private SaveLoadService<ProjectStore> _saveLoadService { get; set; }
        private BackupService<ProjectStore> _backupService { get; set; }
        private RecentFileService _recentFileService { get; set; }

        private bool _hasSaved { get; set; } = false;
        private bool _hasContentUnsaved { get; set; } = false;

        public MainWindow(PluginManager pluginManager, RecentFileService recentFileService)
        {
            InitializeComponent();


            _pluginManager = pluginManager;
            _recentFileService = recentFileService;
            _store = new Store();


            DataContext = this;

            _store.OnStoreChanged += OnStore_Changed;
            _store.OnRulePickedCreated += OnRulePicked_Created;
            _store.OnRulePickedDeleted += OnRulePicked_Deleted;
            _store.OnRulePickedUpdated += OnRulePicked_Updated;

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

            PickedRules = new BindingList<RulePickedViewModel>();
        }

        public void OnStore_Changed()
        {

        }

        private void Container_DragEnter(object sender, DragEventArgs e)
        {
            //TODO: Show drag drop panel
        }

        private void Container_DragLeave(object sender, DragEventArgs e)
        {
            //TODO: Hid drag and drop panel

        }
    }

    // HANDLE Rule Control
    public partial class MainWindow
    {
        private void OnRulePicked_Created(RulePickedModel ruleModel)
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

            PickedRules.Add(newRuleViewModel);
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

    // HANDLE Top Menu: Open/Save/Load
    public partial class MainWindow
    {
        public void Open(string path)
        {
            LoadFrom(path);
        }

        public void Save()
        {
            if (!_hasSaved)
            {
                SaveAs();
                return;
            }

            //_saveLoadService.Save();
        }

        public void SaveAs()
        {

        }

        public void StartConvert()
        {
            List<IRenameRule> rules = _store.GetAllPickedRule().Select(pickedRule =>
            {
                string ruleId = pickedRule.RuleId;

                IRenameRule rule = _pluginManager.CreateRule(ruleId);
                rule.SetParameter(pickedRule.Paramter);

                return rule;
            }).ToList();

            List<FileInfor> files = _store.GetAllNodeConverts().Select(nodeConvert =>
            {
                return new FileInfor
                {
                    FileName = nodeConvert.Node.Name,
                    Dir = nodeConvert.Node.Path,
                    Extension = nodeConvert.Node.Extension
                };
            }).ToList();

            ConvertPipeline pipeline = new ConvertPipeline(rules);

            pipeline.Convert(files, (result, err) =>
            {
                Debug.WriteLine(result.FileName);
                Debug.WriteLine(err);
            });
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
            StartConvert();
        }
    }

    public partial class MainWindow
    {
        private void FilesControl_OnAddFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    if (_list == null)
            //    {
            //        _list = new List<string>(openFileDialog.FileNames);
            //        nodeList = new List<Node>();
            //    }
            //    else
            //        foreach (var file in openFileDialog.FileNames)
            //        {
            //            if (!_list.Contains(file))
            //                _list.Add(file);
            //        }
            //    foreach (var path in openFileDialog.FileNames)
            //    {
            //        string extention = Path.GetExtension(path);
            //        string filename = Path.GetFileName(path);
            //        DateTime creation = File.GetCreationTime(path);
            //        string size = extention.Length == 0 ? string.Empty : new System.IO.FileInfo(path).Length.ToString();
            //        Node node = new Node()
            //        {
            //            Path = path,
            //            Extension = extention,
            //            Name = Name,
            //            CreatedDate = creation,
            //            Size = size
            //        };
            //        nodeList.Add(node);
            //    }
            //}

        }
    }
}