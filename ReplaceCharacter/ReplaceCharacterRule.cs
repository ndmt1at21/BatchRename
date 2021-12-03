using PluginContract;
using System;
using System.Linq;

namespace ReplaceCharacter
{
    public class ReplaceCharacterRule : IRenameRule
    {
        public string Id => "ReplaceCharacter";

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            ReplaceCharacterParameter parameter = (ReplaceCharacterParameter)ruleParameter;

            if (parameter == null)
                return null;

            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName.Replace(parameter.oldChar, parameter.newChar)
            };
        }

        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            return files.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            ReplaceCharacterParameter parameter = (ReplaceCharacterParameter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Replace ${parameter.oldChar} in file name `${file.FileName}` to ${parameter.newChar}";
        }
    }
}
