using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToPascalCase
{
	public class ToPascalCasePlugin : IRulePlugin
	{
		public string ID => "PascalCase";

		public string Name => "To PascalCase";

		public IRuleComponent CreateComponentInstance()
		{
			throw new NotImplementedException();
		}

		public IRenameRule CreateRuleInstance()
		{
			throw new NotImplementedException();
		}
	}
}
