using Newtonsoft.Json;

namespace Utils
{
    public static class Object
    {
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
            return (T)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(o));
        }
    }
}