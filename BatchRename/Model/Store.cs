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

        public Store()
        {
            RecentFiles = new List<RecentFileItem>();
            PickedRules = new Dictionary<string, RulePickedModel>();
            EditingRules = new Dictionary<string, RuleEditingModel>();
            ConvertNodes = new Dictionary<string, NodeConvertModel>();
            OutputPath = null;
        }
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
        public Action<IEnumerable<string>> OnRulePickedDeleted;

        public List<RulePickedModel> GetAllPickedRule()
        {
            return PickedRules.Values.ToList();
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
            if (result) OnRulePickedDeleted?.Invoke(new List<string> { pickedRuleId });
            OnStoreChanged?.Invoke();
        }

        public void DeletePickedRules(IEnumerable<string> pickedRuleIds)
        {
            List<string> deletedIds = new List<string>();

            foreach (var pickedRuleId in pickedRuleIds)
            {
                bool result = PickedRules.Remove(pickedRuleId);
                if (result) deletedIds.Add(pickedRuleId);
            }

            OnNodeConvertDeleted?.Invoke(deletedIds);
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
                return EditingRules[ruleId];

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

        public string OutputPath { get; set; }

        public Action<NodeConvertModel> OnNodeConvertUpdated;
        public Action<NodeConvertModel> OnNodeConvertCreated;
        public Action<IEnumerable<string>> OnNodeConvertDeleted;

        public void CreateNodeConvert(NodeConvertModel nodeConvert)
        {
            NodeConvertModel newNode = nodeConvert.Clone();
            newNode.Id = Guid.NewGuid().ToString();

            ConvertNodes.Add(newNode.Id, newNode);

            OnNodeConvertCreated?.Invoke(newNode.Clone());
            OnStoreChanged?.Invoke();
        }

        public List<NodeConvertModel> GetAllNodeConverts()
        {
            return ConvertNodes.Values.ToList();
        }

        public NodeConvertModel GetNodeConvert(string id)
        {
            return ConvertNodes[id];
        }

        public void UpdateNodeConvert(NodeConvertModel updatedNodeConvert)
        {
            NodeConvertModel existNode = ConvertNodes[updatedNodeConvert.Id].Clone();

            if (existNode == null) return;

            if (updatedNodeConvert.Node != null)
                existNode.Node = updatedNodeConvert.Node.Clone();

            existNode.ConvertStatus = updatedNodeConvert.ConvertStatus;

            ConvertNodes[existNode.Id] = existNode;

            OnNodeConvertCreated?.Invoke(existNode.Clone());
            OnStoreChanged?.Invoke();
        }

        public void DeleteNodeConvert(string nodeConvertId)
        {
            ConvertNodes.Remove(nodeConvertId);
            OnNodeConvertDeleted?.Invoke(new List<string>() { nodeConvertId });
            OnStoreChanged?.Invoke();
        }

        public void DeleteNodeConverts(IEnumerable<string> nodeConvertIds)
        {
            List<string> deletedIds = new List<string>();

            foreach (var nodeConvertId in nodeConvertIds)
            {
                bool result = ConvertNodes.Remove(nodeConvertId);
                if (result) deletedIds.Add(nodeConvertId);
            }

            OnNodeConvertDeleted?.Invoke(deletedIds);
            OnStoreChanged?.Invoke();
        }
    }

    public partial class Store
    {
        public List<RecentFileItem> RecentFiles { get; set; }
    }
}