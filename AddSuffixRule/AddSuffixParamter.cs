using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSuffixRule
{
    public class AddSuffixParamter : IRuleParameter
    {
        public string Id => "AddSuffix";

        public string Suffix;
    }
}
