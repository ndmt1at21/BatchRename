using System;
using System.Windows.Controls;

namespace PluginContract
{
    public interface IRuleComponent
    {
        IRuleParameter GetRuleParamter();

        void SetRuleParameter(IRuleParameter ruleParameter);

        Control GetView();
    }
}