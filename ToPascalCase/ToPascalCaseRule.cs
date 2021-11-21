using PluginContract;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToPascalCase
{
	public class ToPascalCaseRule : IRenameRule
	{
		public string Convert(string fileName, IRuleParameter ruleParameter)
		{
			return Utils.Rule.ToPascalCase(Utils.Rule.RemoveUnicode(fileName));
		}

		public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
		{
			return fileName.Select(f => Convert(f, ruleParameter)).ToArray();
		}

		public string GetStatement(string fileName, IRuleParameter ruleParameter)
		{
			return $"To PascalCase and remove unicoe from {fileName}";
		}
	}
}
