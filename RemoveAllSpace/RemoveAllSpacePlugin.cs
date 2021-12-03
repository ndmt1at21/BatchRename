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
        public string Id => "RemoveAllSpaces";

        public string Name => "Remove all sapces";

        public IRenameRule CreateRuleInstance()
        {
            return new RemoveAllSpaceRule();
        }
        public IRuleComponent CreateComponentInstance()
        {
            return new RemoveAllSpaceComponent();
        }
    }
}
