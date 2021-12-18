using PluginContract;
using System;
using System.Linq;

namespace TrimSpaceRule
{
    public class TrimSpaceRule : IRenameRule
    {
        public string Id => "TrimSpace";

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
                FileName = file.FileName
            };
        }

        public FileInfor[] Convert(FileInfor[] files)
        {
            return files.Select(f => Convert(f)).ToArray();
        }

        public string GetStatement()
        {
            return $"Remove space from at the beginning and the end";
        }
    }
}
