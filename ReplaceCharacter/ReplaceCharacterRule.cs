using PluginContract;
using System;
using System.Linq;

namespace ReplaceCharacter
{
    public class ReplaceCharacterRule : IRenameRule
    {
        public string Convert(string fileName, IRuleParameter ruleParameter)
        {
            ReplaceCharacterParameter parameter = (ReplaceCharacterParameter)ruleParameter;

            if (parameter == null)
                return null;

            return fileName.Replace(parameter.oldChar,parameter.newChar);
        }

        public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
        {
            return fileName.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(string fileName, IRuleParameter ruleParameter)
        {
            ReplaceCharacterParameter parameter = (ReplaceCharacterParameter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Replace ${parameter.oldChar} in file name `${fileName}` to ${parameter.newChar}";
        }
    }
}
