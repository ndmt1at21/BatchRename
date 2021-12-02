using System;

namespace PluginContract
{
    public interface IRulePlugin : IRuleIdentify
    {
        string Name { get; }

        IRenameRule CreateRuleInstance();

        IRuleComponent CreateComponentInstance();
    }
}