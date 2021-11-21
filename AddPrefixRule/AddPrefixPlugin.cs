using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPrefixRule
{
    public class AddPrefixPlugin : IRulePlugin
    {
        public string ID { get; } = "AddPrefix";

        public string Name { get; } = "Add Prefix";

        public IRenameRule CreateRuleInstance()
        {
            return new AddPrefixRule();
        }

        public IRuleComponent CreateComponentInstance()
        {
            return new AddPrefixComponent();
        }
    }
}
