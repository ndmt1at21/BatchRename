using System;
using System.Windows.Controls;

namespace PluginContract
{
    public delegate void HandlerParameterChange(RuleParameter ruleParameter);

    public interface IRuleComponent
    {
        RuleParameter Parameter { get; set; }
    }
}