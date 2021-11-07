using Newtonsoft.Json;
using System;
using System.IO;

namespace BatchRename.Store
{
    public class StoreBase
    {
        public void Save(String path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this));
        }

        public static StoreBase Load(String path)
        {
            StoreBase store = (StoreBase)JsonConvert.DeserializeObject(File.ReadAllText(path));
            return store;
        }
    }
}