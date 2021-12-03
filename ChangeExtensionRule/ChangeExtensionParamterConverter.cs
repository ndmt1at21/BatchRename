using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ChangeExtensionRule
{
    public class ChangeExtensionParamterConverter : IRuleParamterCoverter
    {
        public string Id => "ChangeExtensionParamter";

        public IRuleParameter DeserializeParameter(string serializeParams)
        {
            ChangeExtensionParamter parameter = (ChangeExtensionParamter)Utils.Object.JsonDeserialize(serializeParams);

            if (parameter == null)
                return null;

            return parameter;
        }

        public string Serialize(IRuleParameter ruleParamter)
        {
            ChangeExtensionParamter parameter = (ChangeExtensionParamter)ruleParamter;

            if (parameter == null)
                return null;

            return Utils.Object.JsonSerializer(parameter);
        }
    }
}