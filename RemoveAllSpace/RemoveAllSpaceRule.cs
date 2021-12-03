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

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName.Replace(" ", "")
            };
        }

        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            return files.Select(f => Convert(f, ruleParameter)).ToArray(); lementedException();
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            return $"Remove all sapces in {file.FileName}";
        }
    }
}
