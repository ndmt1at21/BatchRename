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

        public IRuleComponent CreateComponentInstance()
        {
            throw new NotImplementedException();
        }

        public IRuleComponent CreateComponentInstance(string serializeRuleParameter)
        {
            throw new NotImplementedException();
        }

        public IRuleComponent CreateComponentInstance(IRuleParameter ruleParamter)
        {
            throw new NotImplementedException();
        }

        public IRenameRule CreateRuleInstance()
        {
            throw new NotImplementedException();
        }
    }
}
