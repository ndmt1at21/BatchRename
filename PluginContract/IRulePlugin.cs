using System;

namespace PluginContract
{
    public interface IRulePlugin
    {
        string ID { get; }
        string Name { get; }

        IRenameRule CreateRuleInstance();

        IRuleComponent CreateComponentInstance();
    }
}