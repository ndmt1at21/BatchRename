using System;

namespace PluginContract
{
    public interface IRenameRule : IRuleIdentify
    {
        void SetParameter(IRuleParameter ruleParameter);

        FileInfor Convert(FileInfor file);

        FileInfor[] Convert(FileInfor[] files);

        string GetStatement(FileInfor file);
    }
}