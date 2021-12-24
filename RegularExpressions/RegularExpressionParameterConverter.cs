using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressions
{
	public class RegularExpressionParameterConverter : IRuleParamterCoverter
	{
		public string Id => "RegularExpression";

		public IRuleParameter DeserializeParameter(string serializeParams)
		{
			RegularExpressionParameter parameter = (RegularExpressionParameter)Utils.Object.JsonDeserialize(serializeParams);

			if (parameter == null)
				return null;

			return parameter;
		}

		public string Serialize(IRuleParameter ruleParamter)
		{
			RegularExpressionParameter parameter = (RegularExpressionParameter)ruleParamter;

			if (parameter == null)
				return null;

			return Utils.Object.JsonSerializer(parameter);
		}
	}
}
