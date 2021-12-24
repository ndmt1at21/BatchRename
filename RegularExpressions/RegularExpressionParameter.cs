using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegularExpressions
{
	public class RegularExpressionParameter : IRuleParameter
	{
		public string Id => "RegularExpression";
		public string Regex { get; set; }
	}
}
