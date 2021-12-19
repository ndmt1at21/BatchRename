using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceCharacter
{
    class ReplaceCharacterPlugin : IRulePlugin
    {
        public string Id => "ReplaceCharacter";

        public string Name { get; } = "Replace character rule";

        public IRenameRule CreateRuleInstance()
        {
            return new ReplaceCharacterRule();
        }
        public IRuleComponent CreateComponentInstance()
        {
            return new ReplaceCharacterComponent();
        }
    }
}
