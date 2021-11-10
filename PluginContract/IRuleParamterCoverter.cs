namespace PluginContract
{
    public interface IRuleParamterCoverter
    {
        public string Serialize(IRuleParameter ruleParamter);

        public IRuleParameter DeserializeParameter(string serializeParams);

        public string GetStatement(IRuleParameter ruleParameter);
    }
}