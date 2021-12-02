namespace PluginContract
{
    public interface IRuleParamterCoverter : IRuleIdentify
    {
        public string Serialize(IRuleParameter ruleParamter);

        public IRuleParameter DeserializeParameter(string serializeParams);
    }
}