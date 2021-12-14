using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatchRename.Model;
using System.IO;
using Newtonsoft.Json;

namespace BatchRename.Lib
{
    public class SaveLoadManager<T>
    {
        public T Load(string path)
        {
            try
            {
                string text = File.ReadAllText(path);

                T store = (T)JsonConvert.DeserializeObject(text);

                if (store == null)
                    throw new InvalidCastException("");

                return store;
            }
            catch
            {
                throw;
            }
        }

        public void Save(T store, string path)
        {
            try
            {
                string content = JsonConvert.SerializeObject(store);
                File.WriteAllText(path, content);
            }
            catch
            {
                throw;
            }
        }

        public Task SaveAsync(T data, string path)
        {
            return Task.Run(() =>
            {
                string content = JsonConvert.SerializeObject(data);
                File.WriteAllText(path, content);
            });
        }
    }
}
