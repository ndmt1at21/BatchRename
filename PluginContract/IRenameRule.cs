using System;

namespace PluginContract
{
    public interface IRenameRule : IRuleIdentify
    {
        string Convert(FileInfor file, IRuleParameter ruleParameter);

        string[] Convert(FileInfor[] files, IRuleParameter ruleParameter);

        string GetStatement(FileInfor file, IRuleParameter ruleParameter);
    }
}