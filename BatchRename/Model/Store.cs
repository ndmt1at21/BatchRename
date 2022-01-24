using BatchRename.Lib;
using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public partial class Store
    {
        public Action OnStoreChanged { get; set; }
        public Action OnStoreLoaded { get; set; }

        public Store()
        {
            RecentFiles = new List<RecentFileItem>();
            PickedRules = new Dictionary<string, RulePickedModel>();
            EditingRules = new Dictionary<string, RuleEditingModel>();
            ConvertNodes = new Dictionary<string, NodeConvertModel>();
            OutputPath = null;
        }

        public void LoadStoreFrom(ProjectStore projectStore)
        {
            MainWindowPosition = projectStore.MainWindowPosition;
            DialogSelectRulePosition = projectStore.DialogSelectRulePosition;
            PickedRules = projectStore.PickedRules;
            EditingRules = projectStore.EditingRules;
            ConvertNodes = projectStore.ConvertNodes;
            OutputPath = projectStore.OutputPath;

            if (PickedRules == null)
            {
                PickedRules = new Dictionary<string, RulePickedModel>();
            }

            if (EditingRules == null)
            {
                EditingRules = new Dictionary<string, RuleEditingModel>();
            }

            if (ConvertNodes == null)
            {
                ConvertNodes = new Dictionary<string, NodeConvertModel>();
            }

            OnStoreLoaded?.Invoke();
        }

        public ProjectStore ExportProjectStore()
        {
            return new ProjectStore
            {
                MainWindowPosition = MainWindowPosition,
                DialogSelectRulePosition = DialogSelectRulePosition,
                PickedRules = PickedRules,
                EditingRules = EditingRules,
                ConvertNodes = ConvertNodes,
                OutputPath = OutputPath
            };
        }
    }

    public partial class Store
    {
        private string _currentProjectPath { get; set; }
        public string CurrentProjectPath
        {
            get { return _currentProjectPath; }
            set
            {
                _currentProjectPath = value;
                OnProjectPathChanged?.Invoke();
            }
        }

        public bool IsSaveBefore { get; set; } = false;
        public bool IsBlankProject { get; set; } = false;
        public bool HasContentUnsaved { get; set; } = false;

        public Action OnProjectPathChanged;
    }

    public partial class Store
    {
        public WindowPosition MainWindowPosition { get; set; }
        public WindowPosition DialogSelectRulePosition { get; set; }

        public Action<WindowPosition> OnMainWindowPositionUpdated;
        public Action<WindowPosition> OnDialogSelectRulePositionUpdated;

        public void UpdateMainWindowPosition(WindowPosition position)
        {
            MainWindowPosition = position.Clone();
            OnMainWindowPositionUpdated?.Invoke(position.Clone());
        }

        public void UpdateDialogSelectRulePosition(WindowPosition position)
        {
            DialogSelectRulePosition = position.Clone();
            OnDialogSelectRulePositionUpdated?.Invoke(position.Clone());
        }
    }

    // Rule Picked
    public partial class Store
    {
        public Dictionary<string, RulePickedModel> PickedRules { get; set; }

        public Action<RulePickedModel> OnRulePickedCreated;
        public Action<RulePickedModel> OnRulePickedUpdated;
        public Action<string> OnRulePickedDeleted;

        public List<RulePickedModel> GetAllPickedRule()
        {
            return Utils.Object.DeepClone(PickedRules.Values.ToList());
        }

        public RulePickedModel GetPickedRule(string id)
        {
            return Utils.Object.DeepClone(PickedRules[id]);
        }

        public void CreatePickedRule(RulePickedModel ruleModel)
        {
            ruleModel.Id = Guid.NewGuid().ToString();
            PickedRules.Add(ruleModel.Id, ruleModel.Clone());
            OnRulePickedCreated?.Invoke(ruleModel);
            OnStoreChanged?.Invoke();
        }

        public void UpdatePickedRule(RulePickedUpdateModel ruleUpdateModel)
        {
            var rule = PickedRules[ruleUpdateModel.Id];

            if (ruleUpdateModel.IsMarked != null)
                rule.IsMarked = (bool)ruleUpdateModel.IsMarked;

            if (ruleUpdateModel.Paramter != null)
                rule.Paramter = ruleUpdateModel.Paramter;

            if (ruleUpdateModel.Position != null)
                rule.Position = (long)ruleUpdateModel.Position;

            var ruleClone = rule.Clone();
            PickedRules[ruleUpdateModel.Id] = ruleClone;

            OnRulePickedUpdated?.Invoke(ruleClone);
            OnStoreChanged?.Invoke();
        }

        public void DeletePickedRule(string pickedRuleId)
        {
            bool result = PickedRules.Remove(pickedRuleId);
            if (result) OnRulePickedDeleted?.Invoke(pickedRuleId);
            OnStoreChanged?.Invoke();
        }
    }

    // Rule Editing
    public partial class Store
    {
        public Dictionary<string, RuleEditingModel> EditingRules { get; set; }

        public Action<RuleEditingModel> OnEditingRuleCreated;
        public Action<RuleEditingModel> OnEditingRuleUpdated;

        public void CreateEditingRule(RuleEditingModel ruleModel)
        {
            EditingRules.Add(ruleModel.RuleId, ruleModel.Clone());
            OnEditingRuleCreated?.Invoke(ruleModel);
            OnStoreChanged?.Invoke();
        }

        public RuleEditingModel GetEditingRule(string ruleId)
        {
            if (EditingRules.ContainsKey(ruleId))
                return Utils.Object.DeepClone(EditingRules[ruleId]);

            return null;
        }

        public void UpdateEditingRule(RuleEditingModel ruleModel)
        {
            if (EditingRules.ContainsKey(ruleModel.RuleId) == false)
                return;

            EditingRules[ruleModel.RuleId] = ruleModel.Clone();

            OnEditingRuleUpdated?.Invoke(ruleModel.Clone());
            OnStoreChanged?.Invoke();
        }
    }

    public partial class Store
    {
        public Dictionary<string, NodeConvertModel> ConvertNodes { get; set; }

        private string _outputPath { get; set; }
        public string OutputPath
        {
            get
            {
                return _outputPath;
            }
            set
            {
                _outputPath = value;
                OnOutputPathChanged?.Invoke(value);
            }
        }

        public Action<NodeConvertModel> OnNodeConvertUpdated;
        public Action<NodeConvertModel> OnNodeConvertCreated;
        public Action<string> OnNodeConvertDeleted;
        public Action<string> OnOutputPathChanged;

        public void CreateNodeConvert(NodeConvertModel nodeConvert)
        {
            NodeConvertModel newNode = nodeConvert.Clone();
            newNode.Id = Guid.NewGuid().ToString();

            Debug.WriteLine(newNode.Id);

            ConvertNodes.Add(newNode.Id, newNode);

            OnNodeConvertCreated?.Invoke(newNode.Clone());
            OnStoreChanged?.Invoke();
        }

        public List<NodeConvertModel> GetAllNodeConverts()
        {
            return Utils.Object.DeepClone(ConvertNodes.Values.ToList());
        }

        public NodeConvertModel GetNodeConvert(string id)
        {
            return Utils.Object.DeepClone(ConvertNodes[id]);
        }

        public void UpdateNodeConvert(NodeConvertModel updatedNodeConvert)
        {
            NodeConvertModel existNode = ConvertNodes[updatedNodeConvert.Id].Clone();

            if (existNode == null) return;

            existNode.Node = updatedNodeConvert.Node.Clone();
            existNode.ConvertStatus = updatedNodeConvert.ConvertStatus;
            existNode.NewName = updatedNodeConvert.NewName;
            existNode.IsMarked = updatedNodeConvert.IsMarked;
            existNode.Error = updatedNodeConvert.Error;

            ConvertNodes[existNode.Id] = existNode;

            OnNodeConvertUpdated?.Invoke(existNode.Clone());
            OnStoreChanged?.Invoke();
        }

        public void DeleteNodeConvert(string nodeConvertId)
        {
            ConvertNodes.Remove(nodeConvertId);
            OnNodeConvertDeleted?.Invoke(nodeConvertId);
            OnStoreChanged?.Invoke();
        }
    }

    public partial class Store
    {
        public List<RecentFileItem> RecentFiles { get; set; }
    }
}