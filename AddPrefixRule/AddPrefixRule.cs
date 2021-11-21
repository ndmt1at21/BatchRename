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

        public string Convert(string fileName, IRuleParameter ruleParameter)
        {
            AddPrefixParamter parameter = (AddPrefixParamter)ruleParameter;

            if (parameter == null)
                return null;

            return parameter.Prefix + fileName;
        }

        public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
        {
            return fileName.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(string fileName, IRuleParameter ruleParameter)
        {
            AddPrefixParamter parameter = (AddPrefixParamter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Add prefix ${parameter.Prefix} to file name ${fileName}";
        }
    }
}
