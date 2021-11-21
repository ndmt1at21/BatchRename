using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllSpace
{
	public class RemoveAllSpaceRule : IRenameRule
	{
		public string Convert(string fileName, IRuleParameter ruleParameter)
		{
			return fileName.Replace(" ", "");
		}

		public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
		{
			return fileName.Select(f => Convert(f, ruleParameter)).ToArray();
		}

		public string GetStatement(string fileName, IRuleParameter ruleParameter)
		{
			return $"Remove all sapces in {fileName}";
		}
	}
}
