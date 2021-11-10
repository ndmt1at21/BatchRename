using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeExtensionRule
{
    public class ChangeExtensionPlugin : IRulePlugin
    {
        public string ID { get; } = "ChangeExtension";

        public string Name { get; } = "Change Extension";

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
            return new ChangeExtensionRule();
        }
    }
}