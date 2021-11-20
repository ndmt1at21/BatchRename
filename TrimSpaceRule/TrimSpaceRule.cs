using PluginContract;
using System;
using System.Linq;

namespace TrimSpaceRule
{
    public class TrimSpaceRule : IRenameRule
    {
        public string Convert(string fileName, IRuleParameter ruleParameter)
        {
            return fileName.Trim();
        }

        public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
        {
            return fileName.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(string fileName, IRuleParameter ruleParameter)
        {
            return $"Remove space from at the beginning and the end of `${fileName}`";
        }
    }
}
