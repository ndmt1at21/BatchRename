using BatchRename.Model;
using System.Collections.Generic;
using BatchRename;

namespace BatchRename.Store
{
    internal class DialogRuleParameterStore
    {
        private readonly List<RuleData> ruleDatas;

        public DialogRuleParameterStore()
        {
            ruleDatas = new List<RuleData>();
        }

        public void Add(RuleData ruleState)
        {
            ruleDatas.Add(Utils.DeepClone(ruleState));
        }

        public void Change(int index, RuleData ruleData)
        {
            ruleDatas[index] = Utils.DeepClone(ruleData);
        }

        public RuleData[] GetAll()
        {
            return ruleDatas.ToArray();
        }
    }
}