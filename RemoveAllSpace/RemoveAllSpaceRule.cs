using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllSpace
{
    public class RemoveAllSpaceRule : IRenameRule
    {
        public string Id => "RemoveAllSpaces";

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
                FileName = file.FileName.Replace(" ", "")
            };
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            return files.Select(f => Convert(f)).ToArray();
        }

        public string GetStatement(FileInfor file)
        {
            return $"Remove all sapces in {file.FileName}";
        }
    }
}
