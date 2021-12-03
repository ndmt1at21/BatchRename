using PluginContract;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToPascalCase
{
    public class ToPascalCaseRule : IRenameRule
    {
        public string Id => throw new NotImplementedException();

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            string newFileName = Utils.Rule.ToPascalCase(Utils.Rule.RemoveUnicode(file.FileName));

            return new FileInfor
            {
                FileName = newFileName,
                Extension = file.Extension,
                Dir = file.Dir
            };
        }

        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            return files.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            return $"To PascalCase and remove unicode from {file.FileName}";
        }
    }
}
