using PluginContract;
using System;
using System.Linq;

namespace ReplaceCharacter
{
    public class ReplaceCharacterRule : IRenameRule
    {
        private ReplaceCharacterParameter _parameter { get; set; }

        public string Id => "ReplaceCharacter";

        public void SetParameter(IRuleParameter ruleParameter)
        {
            _parameter = (ReplaceCharacterParameter)ruleParameter;
        }

        public FileInfor Convert(FileInfor file)
        {
            if (_parameter == null)
                return null;
            string[] splitList = _parameter.oldChar.Split('/');
            string newFileName = file.FileName;
            foreach (string _char in splitList)
            {
                newFileName = newFileName.Replace(_char, _parameter.newChar);
            };
            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = newFileName
            };
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            return files.Select(f => Convert(f)).ToArray();
        }

        public string GetStatement()
        {
            if (_parameter == null)
                return null;

            return $"Replace {_parameter.oldChar} in file name to {_parameter.newChar}";
        }
    }
}
