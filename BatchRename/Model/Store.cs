using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Store
{
    public partial class Store
    {
        public Store()
        {
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
            MainWindowPosition = position;
            OnMainWindowPositionUpdated?.Invoke(position);
        }

        public void UpdateDialogSelectRulePosition(WindowPosition position)
        {
            DialogSelectRulePosition = position;
            OnDialogSelectRulePositionUpdated?.Invoke(position);
        }
    }

    // Rule Picked
    public partial class Store
    {
        public Dictionary<string, RulePickedModel> pickedRules;

        public Action<RulePickedModel> OnRulePickedCreated;
        public Action<RulePickedModel> OnRulePickedUpdated;
        public Action<string> OnRulePickedDeleted;

        public List<RulePickedModel> GetAllPickedRule()
        {
            return pickedRules.Values.ToList();
        }

        public void CreatePickedRule(RulePickedModel ruleModel)
        {
            ruleModel.Id = Guid.NewGuid().ToString();
            pickedRules.Add(ruleModel.Id, ruleModel);
            OnRulePickedCreated?.Invoke(ruleModel);
        }

        public void UpdatePickedRule(RulePickedModel ruleModel)
        {
            pickedRules[ruleModel.Id] = ruleModel;
            OnRulePickedUpdated?.Invoke(ruleModel);
        }

        public void DeletePickedRule(string pickedRuleId)
        {
            pickedRules.Remove(pickedRuleId);
            OnRulePickedDeleted?.Invoke(pickedRuleId);
        }
    }

    // Rule Editing
    public partial class Store
    {
        public Dictionary<string, RuleEditingModel> editingRules;

        public Action<RuleEditingModel> OnEditingRuleUpdated;

        public void UpdateEditingRule(RuleEditingModel ruleModel)
        {
            if (editingRules.ContainsKey(ruleModel.RuleId) == false)
                editingRules.Add(ruleModel.RuleId, ruleModel);
            editingRules[ruleModel.RuleId] = ruleModel;

            OnEditingRuleUpdated?.Invoke(ruleModel);
        }
    }
}