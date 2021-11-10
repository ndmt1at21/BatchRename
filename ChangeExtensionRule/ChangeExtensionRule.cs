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
        public string Convert(string src, IRuleParameter ruleParameter)
        {
            ChangeExtensionParamter parameter = (ChangeExtensionParamter)ruleParameter;

            if (parameter == null)
                return null;

            return src + parameter.NewExtension;
        }

        public string GetStatement(IRuleParameter ruleParameter)
        {
            return null;
        }
    }
}