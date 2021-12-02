using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace TrimSpaceRule
{
    public class TrimSpaceParameter : IRuleParameter
    {
        public string Id => "TrimSpace";
    }
}
