using System;

namespace PluginContract
{
    public interface IRenameRule
    {
        String Convert(String src, RuleParameter ruleParameter);

        String GetStatement(RuleParameter ruleParameter);
    }
}