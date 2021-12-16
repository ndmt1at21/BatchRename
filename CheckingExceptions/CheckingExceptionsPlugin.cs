using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingExceptions
{
    class CheckingExceptionsPlugin : IRulePlugin
    {
        public string Id { get; } = "CheckingExceptions";

        public string Name { get; } = "Checking Exceptions";

        public IRenameRule CreateRuleInstance()
        {
            return new CheckingExceptionsRule();
        }

        public IRuleComponent CreateComponentInstance()
        {
            return new CheckingExceptionsComponent();
        }
    }
}
