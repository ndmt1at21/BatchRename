using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowercaseCharacter
{
	public class LowercaseRule : IRenameRule
	{
		public string Convert(string fileName, IRuleParameter ruleParameter)
		{
			return fileName.ToLower();
		}

		public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
		{
			return fileName.Select(f => Convert(f, ruleParameter)).ToArray();
		}

		public string GetStatement(string fileName, IRuleParameter ruleParameter)
		{
			return $"To lowercase file name{fileName}";
		}
	}
}
