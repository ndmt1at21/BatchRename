using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegularExpressions
{
	public class RegularExpressionPlugin : IRulePlugin
	{
		public string Name => "Regular Expression";

		public string Id => "RegularExpression";

		public IRuleComponent CreateComponentInstance()
		{
			return new RegularExpressionComponent();
		}

		public IRenameRule CreateRuleInstance()
		{
			return new RegularExpressionRule();
		}
	}
}
