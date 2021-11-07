using BatchRename.Model;
using System.Collections.Generic;

namespace BatchRename.Store
{
    public class SelectedRuleParamterStore
    {
        private readonly List<RuleData> ruleDatas;

        public SelectedRuleParamterStore()
        {
            ruleDatas = new List<RuleData>();
        }

        public void Add(RuleData ruleData)
        {
            ruleDatas.Add(Utils.DeepClone(ruleData));
        }

        public RuleData[] GetAll()
        {
            return ruleDatas.ToArray();
        }

        public void Change(int index, RuleData ruleData)
        {
            ruleDatas[index] = Utils.DeepClone(ruleData);
        }

        public void Delete(int index)
        {
            ruleDatas.RemoveAt(index);
        }
    }
}