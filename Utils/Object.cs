using Newtonsoft.Json;

namespace Utils
{
    public static class Object
    {
        private static readonly JsonSerializerSettings _serializeSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
        };

        public static string JsonSerializer(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static object JsonDeserialize(string serializeJson)
        {
            return JsonConvert.DeserializeObject(serializeJson);
        }

        public static T DeepClone<T>(T o)
        {
            return JsonConvert.DeserializeObject<T>(
                JsonConvert.SerializeObject(o, _serializeSettings),
                _serializeSettings
            );
        }
    }
}