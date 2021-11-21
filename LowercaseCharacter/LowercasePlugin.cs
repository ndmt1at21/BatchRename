﻿using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowercaseCharacter
{
	public class LowercasePlugin : IRulePlugin
	{
		public string ID => "toLowercase";

		public string Name => "All characters to lowercase";

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
