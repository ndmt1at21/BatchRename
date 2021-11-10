using System;

namespace PluginContract
{
    public interface IRulePlugin
    {
        string ID { get; }
        string Name { get; }

        IRenameRule CreateRuleInstance();

        IRuleComponent CreateComponentInstance();

        IRuleComponent CreateComponentInstance(string serializeRuleParameter);

        IRuleComponent CreateComponentInstance(IRuleParameter ruleParamter);
    }
}