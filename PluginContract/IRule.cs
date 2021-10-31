using System;

namespace PluginContract
{
    public interface IRule
    {
        String Convert(String src, RuleParameter ruleParameter);
    }
}