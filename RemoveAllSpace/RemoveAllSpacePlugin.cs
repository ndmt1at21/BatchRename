using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllSpace
{
	public class RemoveAllSpacePlugin : IRulePlugin
	{
		public string ID => "RemoveAllSpaces";

		public string Name => "Remove all sapces";

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
