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
        public string Id => "ChangeExtensionParamter";

        public string Name { get; } = "Change Extension";

        public IRenameRule CreateRuleInstance()
        {
            return new ChangeExtensionRule();
        }

        public IRuleComponent CreateComponentInstance()
        {
            return new ChangeExtensionComponent();
        }
    }
}