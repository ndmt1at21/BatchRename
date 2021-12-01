using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrimSpaceRule
{
    class TrimSpacePlugin : IRulePlugin
    {
        public string ID => "TrimSpace";

        public string Name => "Trim Space Before and After Name";

        public IRenameRule CreateRuleInstance()
        {
            return new TrimSpaceRule();
        }
        public IRuleComponent CreateComponentInstance()
        {
            return new TrimSpaceComponent();
        }
    }
}
