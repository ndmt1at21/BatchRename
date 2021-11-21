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
        public string Convert(string fileName, IRuleParameter ruleParameter)
        {
            AddSuffixParamter parameter = (AddSuffixParamter)ruleParameter;

            if (parameter == null)
                return null;

            return fileName + parameter.Suffix;
        }

        public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
        {
            return fileName.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(string fileName, IRuleParameter ruleParameter)
        {
            AddSuffixParamter parameter = (AddSuffixParamter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Add prefix ${parameter.Suffix} to file name ${fileName}";
        }
    }
}
