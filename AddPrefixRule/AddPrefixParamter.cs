using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPrefixRule
{
    public class AddPrefixParamter : IRuleParameter
    {
        public string Id => "AddPrefix";

        public string Prefix { get; set; }
    }
}
