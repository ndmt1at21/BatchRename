using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BatchRename.Lib
{
    public class JsonPersister : IPersister
    {
        public JsonPersister()
        {
        }

        public object Load(string path)
        {
            return JsonConvert.DeserializeObject(File.ReadAllText(path));
        }

        public void Save(string path, object data)
        {
            string content = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, content);
        }

        public Task SaveAsync(string path, object data)
        {
            return Task.Run(async () =>
            {
                string content = JsonConvert.SerializeObject(data);
                await File.WriteAllTextAsync(path, content);
            });
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
