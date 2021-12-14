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
        public Store()
        {
            pickedRules = new Dictionary<string, RulePickedModel>();
            editingRules = new Dictionary<string, RuleEditingModel>();
            convertNodes = new Dictionary<string, NodeConvertModel>();
            outputPath = null;
        }

        private static Store _store;
        public static Store Shared
        {
            get
            {
                if (_store == null)
                    _store = new Store();
                return _store;
            }
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
        private Dictionary<string, RulePickedModel> pickedRules { get; set; }

        public Action<RulePickedModel> OnRulePickedCreated;
        public Action<RulePickedModel> OnRulePickedUpdated;
        public Action<IEnumerable<string>> OnRulePickedDeleted;

        public List<RulePickedModel> GetAllPickedRule()
        {
            return pickedRules.Values.ToList();
        }

        public void CreatePickedRule(RulePickedModel ruleModel)
        {
            ruleModel.Id = Guid.NewGuid().ToString();
            pickedRules.Add(ruleModel.Id, ruleModel.Clone());
            OnRulePickedCreated?.Invoke(ruleModel);
        }

        public void UpdatePickedRule(RulePickedUpdateModel ruleUpdateModel)
        {
            var rule = pickedRules[ruleUpdateModel.Id];

            if (ruleUpdateModel.IsMarked != null)
                rule.IsMarked = (bool)ruleUpdateModel.IsMarked;

            if (ruleUpdateModel.Paramter != null)
                rule.Paramter = ruleUpdateModel.Paramter;

            if (ruleUpdateModel.Position != null)
                rule.Position = (long)ruleUpdateModel.Position;

            var ruleClone = rule.Clone();
            pickedRules[ruleUpdateModel.Id] = ruleClone;

            OnRulePickedUpdated?.Invoke(ruleClone);
        }

        public void DeletePickedRule(string pickedRuleId)
        {
            bool result = pickedRules.Remove(pickedRuleId);
            if (result) OnRulePickedDeleted?.Invoke(new List<string> { pickedRuleId });
        }

        public void DeletePickedRules(IEnumerable<string> pickedRuleIds)
        {
            List<string> deletedIds = new List<string>();

            foreach (var pickedRuleId in pickedRuleIds)
            {
                bool result = pickedRules.Remove(pickedRuleId);
                if (result) deletedIds.Add(pickedRuleId);
            }

            OnNodeConvertDeleted?.Invoke(deletedIds);
        }
    }

    // Rule Editing
    public partial class Store
    {
        private Dictionary<string, RuleEditingModel> editingRules { get; set; }

        public Action<RuleEditingModel> OnEditingRuleCreated;
        public Action<RuleEditingModel> OnEditingRuleUpdated;

        public void CreateEditingRule(RuleEditingModel ruleModel)
        {
            editingRules.Add(ruleModel.RuleId, ruleModel.Clone());
            OnEditingRuleCreated?.Invoke(ruleModel);
        }

        public RuleEditingModel GetEditingRule(string ruleId)
        {
            if (editingRules.ContainsKey(ruleId))
                return editingRules[ruleId];

            return null;
        }

        public void UpdateEditingRule(RuleEditingModel ruleModel)
        {
            if (editingRules.ContainsKey(ruleModel.RuleId) == false)
                return;

            editingRules[ruleModel.RuleId] = ruleModel.Clone();

            OnEditingRuleUpdated?.Invoke(ruleModel.Clone());
        }
    }

    public partial class Store
    {
        private Dictionary<string, NodeConvertModel> convertNodes { get; set; }

        private string outputPath { get; set; }
        public string OutputPath => outputPath;

        public Action<NodeConvertModel> OnNodeConvertUpdated;
        public Action<NodeConvertModel> OnNodeConvertCreated;
        public Action<IEnumerable<string>> OnNodeConvertDeleted;

        public void CreateNodeConvert(NodeConvertModel nodeConvert)
        {
            NodeConvertModel newNode = nodeConvert.Clone();
            newNode.Id = Guid.NewGuid().ToString();

            convertNodes.Add(newNode.Id, newNode);

            OnNodeConvertCreated?.Invoke(newNode.Clone());
        }

        public List<NodeConvertModel> GetAllNodeConverts()
        {
            return convertNodes.Values.ToList();
        }

        public NodeConvertModel GetNodeConvert(string id)
        {
            return convertNodes[id];
        }

        public void UpdateNodeConvert(NodeConvertModel updatedNodeConvert)
        {
            NodeConvertModel existNode = convertNodes[updatedNodeConvert.Id].Clone();

            if (existNode == null) return;

            if (updatedNodeConvert.Node != null)
                existNode.Node = updatedNodeConvert.Node.Clone();

            existNode.ConvertStatus = updatedNodeConvert.ConvertStatus;

            convertNodes[existNode.Id] = existNode;

            OnNodeConvertCreated?.Invoke(existNode.Clone());
        }

        public void DeleteNodeConvert(string nodeConvertId)
        {
            convertNodes.Remove(nodeConvertId);
            OnNodeConvertDeleted?.Invoke(new List<string>() { nodeConvertId });
        }

        public void DeleteNodeConverts(IEnumerable<string> nodeConvertIds)
        {
            List<string> deletedIds = new List<string>();

            foreach (var nodeConvertId in nodeConvertIds)
            {
                bool result = convertNodes.Remove(nodeConvertId);
                if (result) deletedIds.Add(nodeConvertId);
            }

            OnNodeConvertDeleted?.Invoke(deletedIds);
        }
    }
}