using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeExtensionRule
{
    public class ChangeExtensionRule : IRenameRule
    {
        public string Convert(string fileName, IRuleParameter ruleParameter)
        {
            ChangeExtensionParamter parameter = (ChangeExtensionParamter)ruleParameter;

            if (parameter == null)
                return null;

            return fileName + parameter.NewExtension;
        }

        public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
        {
            return fileName.Select(f => Convert(f, ruleParameter)).ToArray();
        }

        public string GetStatement(string fileName, IRuleParameter ruleParameter)
        {
            ChangeExtensionParamter parameter = (ChangeExtensionParamter)ruleParameter;

            if (parameter == null)
                return null;

            return $"Change file extension from ${fileName} to ${parameter.NewExtension}";
        }
    }
}