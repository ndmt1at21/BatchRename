using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowercaseCharacter
{
    public class LowercaseRule : IRenameRule
    {
        public string Id => "ToLowercase";

        public void SetParameter(IRuleParameter ruleParameter)
        {
            return;
        }

        public FileInfor Convert(FileInfor file)
        {
            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName.ToLower()
            };
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            return files.Select(f => Convert(f)).ToArray();
        }

        public string GetStatement(FileInfor file)
        {
            return $"To lowercase file name {file.FileName}";
        }
    }
}
