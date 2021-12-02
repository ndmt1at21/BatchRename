using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;
using Utils;

namespace AddPrefixRule
{
    public class AddPrefixParamterConverter : IRuleParamterCoverter
    {
        public string Id => "AddPrefix";

        public IRuleParameter DeserializeParameter(string serializeParams)
        {
            AddPrefixParamter parameter = (AddPrefixParamter)Utils.Object.JsonDeserialize(serializeParams);

            if (parameter == null)
                return null;

            return parameter;
        }

        public string Serialize(IRuleParameter ruleParamter)
        {
            AddPrefixParamter parameter = (AddPrefixParamter)ruleParamter;

            if (parameter == null)
                return null;

            return Utils.Object.JsonSerializer(parameter);
        }
    }
}

