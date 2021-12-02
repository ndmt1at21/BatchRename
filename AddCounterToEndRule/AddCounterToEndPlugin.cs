using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace AddCounterToEndRule
{
    public class AddCounterToEndPlugin : IRulePlugin
    {
        public string Id => "AddCounterToEnd";
        public string Name => "Add Counter To End";

        public IRuleComponent CreateComponentInstance()
        {
            return new AddCounterToEndRuleComponent();
        }

        public IRenameRule CreateRuleInstance()
        {
            return new AddCounterToEndRenameRule();
        }
    }
}
