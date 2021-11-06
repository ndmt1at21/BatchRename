using System;

namespace PluginContract
{
    public interface IRule
    {
        String Convert(String src, RuleParameter ruleParameter);

        String GetStatement(RuleParameter ruleParameter);
    }
}