using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace AddCounterToEndRule
{
    public class AddCounterToEndParamterConverter : IRuleParamterCoverter
    {
        public string Id => "AddCounterToEnd";

        public IRuleParameter DeserializeParameter(string serializeParams)
        {
            AddCounterToEndParamter parameter = (AddCounterToEndParamter)Utils.Object.JsonDeserialize(serializeParams);

            if (parameter == null)
                throw new InvalidCastException("Invalid parameter");

            return parameter;
        }

        public string Serialize(IRuleParameter ruleParamter)
        {
            AddCounterToEndParamter parameter = (AddCounterToEndParamter)Utils.Object.JsonDeserialize(serializeParams);

            if (parameter == null)
                throw new InvalidCastException("Invalid parameter");

            return Utils.Object.JsonSerializer(parameter);
        }
    }
}
