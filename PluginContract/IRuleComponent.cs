using System;
using System.Windows.Controls;

namespace PluginContract
{
    public interface IRuleComponent : IRuleIdentify
    {
        IRuleParameter GetRuleParamter();

        void SetRuleParameter(IRuleParameter ruleParameter);

        Control GetView();
    }
}