using System;

namespace PluginContract
{
    public interface IRenameRule
    {
        string Convert(string fileName, IRuleParameter ruleParameter);

        string GetStatement(string fileName, IRuleParameter ruleParameter);
    }
}