using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingExceptions
{
    class CheckingExceptionsParamterConverter : IRuleParamterCoverter
    {
        public string Id => "CheckingExceptions";

        public IRuleParameter DeserializeParameter(string serializeParams)
        {
            CheckingExceptionsParameter parameter = (CheckingExceptionsParameter)Utils.Object.JsonDeserialize(serializeParams);

            if (parameter == null)
                return null;

            return parameter;
        }

        public string Serialize(IRuleParameter ruleParamter)
        {
            CheckingExceptionsParameter parameter = (CheckingExceptionsParameter)ruleParamter;

            if (parameter == null)
                return null;

            return Utils.Object.JsonSerializer(parameter);
        }
    }
}
