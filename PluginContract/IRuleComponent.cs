using System;
using System.Windows.Controls;

namespace PluginContract
{
    public interface IRuleComponent
    {
        IRuleParameter GetRuleParamter();

        void SetRuleParameter(string serializeRuleParamter);

        void SetRuleParameter(IRuleParameter ruleParameter);

        Control GetView();
    }
}