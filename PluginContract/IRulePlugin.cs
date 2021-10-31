using System;

namespace PluginContract
{
    public interface IRulePlugin
    {
        String ID { get; }
        String Name { get; }

        IRule CreateRuleInstance();

        IRuleComponent CreateComponentInstance();
    }
}