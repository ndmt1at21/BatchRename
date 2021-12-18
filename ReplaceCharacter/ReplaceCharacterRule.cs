using PluginContract;
using System;
using System.Linq;

namespace ReplaceCharacter
{
    public class ReplaceCharacterRule : IRenameRule
    {
        private ReplaceCharacterParameter _parameter;

        public string Id => "ReplaceCharacter";

        public void SetParameter(IRuleParameter ruleParameter)
        {
            _parameter = (ReplaceCharacterParameter)ruleParameter;
        }

        public FileInfor Convert(FileInfor file)
        {
            if (_parameter == null)
                return null;

            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName.Replace(_parameter.oldChar, _parameter.newChar)
            };
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            return files.Select(f => Convert(f)).ToArray();
        }

        public string GetStatement(FileInfor file)
        {
            if (_parameter == null)
                return null;

            return $"Replace ${_parameter.oldChar} in file name `${file.FileName}` to ${_parameter.newChar}";
        }
    }
}
