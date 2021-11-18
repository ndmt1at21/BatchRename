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
        public string ID => "ReplaceChar";

        public string Name => "Replace character rule";

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
            return new ReplaceCharacterRule();
        }
    }
}
