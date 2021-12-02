using System;

namespace PluginContract
{
    public interface IRenameRule : IRuleIdentify
    {
        FileInfor Convert(FileInfor file, IRuleParameter ruleParameter);

        FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter);

        FileInfor GetStatement(FileInfor file, IRuleParameter ruleParameter);
    }
}