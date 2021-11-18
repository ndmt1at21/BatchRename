using PluginContract;
using System;

namespace TrimSpaceRule
{
    public class TrimSpaceRule : IRenameRule
    {
        public string Convert(string fileName, IRuleParameter ruleParameter)
        {
            return fileName.Trim();
        }

        public string GetStatement(string fileName, IRuleParameter ruleParameter)
        {
            return $"Remove space from at the beginning and the end of `${fileName}`";
        }
    }
}
