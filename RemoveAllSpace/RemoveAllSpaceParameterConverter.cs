using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllSpace
{
    class RemoveAllSpaceParameterConverter : IRuleParamterCoverter
    {
        public string Id => "RemoveAllSpaces";

        public IRuleParameter DeserializeParameter(string serializeParams)
        {
            RemoveAllSpaceParameter parameter = (RemoveAllSpaceParameter)Utils.Object.JsonDeserialize(serializeParams);

            if (parameter == null)
                return null;

            return parameter;
        }

        public string Serialize(IRuleParameter ruleParamter)
        {
            RemoveAllSpaceParameter parameter = (RemoveAllSpaceParameter)ruleParamter;

            if (parameter == null)
                return null;

            return Utils.Object.JsonSerializer(parameter);
        }
    }
}
