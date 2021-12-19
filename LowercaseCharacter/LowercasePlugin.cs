using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowercaseCharacter
{
    public class LowercasePlugin : IRulePlugin
    {
        public string Id => "ToLowercase";

        public string Name => "All characters to lowercase";

        public IRuleComponent CreateComponentInstance()
        {
            return new LowercaseCharacterComponent();
        }

        public IRenameRule CreateRuleInstance()
        {
            return new LowercaseRule();
        }
    }
}
