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

        static public T DeserializeParameter<T>(String serializeParams) where T : RuleParameter
        {
            return (T)JsonConvert.DeserializeObject(serializeParams);
        }
    }
}