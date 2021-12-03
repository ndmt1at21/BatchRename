using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSuffixRule
{
    class AddSuffixRule : IRenameRule
    {
        public string Id => "AddSuffix";


        public FileInfor[] Convert(FileInfor[] files, IRuleParameter ruleParameter)
        {
            return files.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public FileInfor Convert(FileInfor file, IRuleParameter ruleParameter)
        {
            AddSuffixParamter parameter = (AddSuffixParamter)ruleParameter;

            if (parameter == null)
                return null;

            return new FileInfor
            {
                Dir = file.Dir,
                Extension = file.Extension,
                FileName = file.FileName + parameter.Suffix
            };
        }

        public string GetStatement(FileInfor file, IRuleParameter ruleParameter)
        {
            AddSuffixParamter parameter = (AddSuffixParamter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Add prefix ${parameter.Suffix} to file name ${file.FileName}";
        }
    }
}
