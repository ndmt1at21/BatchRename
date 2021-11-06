using Newtonsoft.Json;
using System;

namespace PluginContract
{
    public class RuleParameter
    {
        public String SerializeParameter()
        {
            return JsonConvert.SerializeObject(this);
        }

        static public RuleParameter DeserializeParameter(String serializeParams)
        {
            return (RuleParameter)JsonConvert.DeserializeObject(serializeParams);
        }
    }
}