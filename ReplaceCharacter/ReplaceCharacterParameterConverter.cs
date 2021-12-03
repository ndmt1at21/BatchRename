using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceCharacter
{
    class ReplaceCharacterParameterConverter : IRuleParamterCoverter
    {
        public string Id => "ReplaceCharacter";

        public IRuleParameter DeserializeParameter(string serializeParams)
        {
            ReplaceCharacterParameter parameter = (ReplaceCharacterParameter)Utils.Object.JsonDeserialize(serializeParams);

            if (parameter == null)
                return null;

            return parameter;
        }

        public string Serialize(IRuleParameter ruleParamter)
        {
            ReplaceCharacterParameter parameter = (ReplaceCharacterParameter)ruleParamter;

            if (parameter == null)
                return null;

            return Utils.Object.JsonSerializer(parameter);
        }
    }
}
