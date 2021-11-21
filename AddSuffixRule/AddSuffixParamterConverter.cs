using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AddSuffixRule
{
    class AddSuffixParamterConverter : IRuleParamterCoverter
    {
        public IRuleParameter DeserializeParameter(string serializeParams)
        {
            AddSuffixParamter parameter = (AddSuffixParamter)Utils.Object.JsonDeserialize(serializeParams);

            if (parameter == null)
                return null;

            return parameter;
        }

        public string Serialize(IRuleParameter ruleParamter)
        {
            AddSuffixParamter parameter = (AddSuffixParamter)ruleParamter;

            if (parameter == null)
                return null;

            return Utils.Object.JsonSerializer(parameter);
        }
    }
}
