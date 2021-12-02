using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPrefixRule
{
    public class AddPrefixRule : IRenameRule
    {
        public string Id => "AddPrefix";

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            AddPrefixParamter parameter = (AddPrefixParamter)ruleParameter;

            if (parameter == null)
                throw new ArgumentException("Invalid parameter");

            return new FileInfor
            {
                Dir = file.Dir,
                FileName = parameter.Prefix + file.FileName,
                Extension = file.Extension
            };
        }

        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            return files.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            AddPrefixParamter parameter = (AddPrefixParamter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Add prefix ${parameter.Prefix} to file name ${file.FileName}";
        }
    }
}
