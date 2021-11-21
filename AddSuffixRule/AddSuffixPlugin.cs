using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSuffixRule 
{
    class AddSuffixPlugin : IRulePlugin
    {
        public string ID { get; } = "AddSuffix";

        public string Name { get; } = "Add Suffix";

        public IRenameRule CreateRuleInstance()
        {
            return new AddSuffixRule();
        }

        public IRuleComponent CreateComponentInstance()
        {
            return new AddSuffixComponent();
        }
    }
}
