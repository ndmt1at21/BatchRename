using System;
using PluginContract;

namespace AddCounterToEndRule
{
    public class AddCounterToEndRule : IRenameRule
    {
        public int count = 0;

        public string Convert(string fileName, IRuleParameter ruleParameter)
        {
            AddCounterToEndParamter ruleParams = (AddCounterToEndParamter)ruleParameter;
            return fileName + ruleParams.Start;
        }

        public string[] Convert(string[] fileName, IRuleParameter ruleParameter)
        {
            throw new NotImplementedException();
        }

        public string GetStatement(string fileName, IRuleParameter ruleParameter)
        {
            throw new NotImplementedException();
        }
    }
}
