using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToPascalCase
{
    public class ToPascalCasePlugin : IRulePlugin
    {
        public string Id => "PascalCase";

        public string Name => "To PascalCase";

        public IRuleComponent CreateComponentInstance()
        {
            return new ToPascalCaseComponent();
        }

        public IRenameRule CreateRuleInstance()
        {
            return new ToPascalCaseRule();
        }
    }
}
