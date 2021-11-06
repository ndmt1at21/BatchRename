using System;
using System.Windows.Controls;

namespace PluginContract
{
    public interface IRuleComponent
    {
        RuleParameter GetRuleParamter();

        void SetRuleParameter(String serializeRuleParamter);

        void SetRuleParameter(RuleParameter ruleParameter);
    }
}