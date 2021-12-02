using PluginContract;
using System;
using System.Linq;

namespace TrimSpaceRule
{
    public class TrimSpaceRule : IRenameRule
    {
        public string Id => "TrimSpace";

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName
            };
        }

        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            return files.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            return $"Remove space from at the beginning and the end of `${file.FileName}`";
        }
    }
}
