using System;

namespace PluginContract
{
    public interface IRenameRule
    {
        string Convert(string src, IRuleParameter ruleParameter);

        string GetStatement(string src, IRuleParameter ruleParameter);
    }
}