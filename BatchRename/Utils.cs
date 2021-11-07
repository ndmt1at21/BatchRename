using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BatchRename
{
    static public class Utils
    {
        static public FileInfo[] GetDllFilesFromFolder(String folderPath)
        {
            DirectoryInfo d = new DirectoryInfo(@folderPath);
            FileInfo[] files = d.GetFiles("*.dll", SearchOption.AllDirectories);

            return files;
        }

        static public Object CreateInstanceFromDllFile(String dllPath, Type targetType, Object[] argsForInstance = null)
        {
            Assembly _Assembly = Assembly.LoadFile(dllPath);
            List<Type> types = _Assembly.GetTypes()?.ToList();
            Type type = types?.Find(a => targetType.IsAssignableFrom(a));

            if (type == null)
                return null;

            return argsForInstance == null
                ? Activator.CreateInstance(type)
                : Activator.CreateInstance(type, argsForInstance);
        }

        static public T DeepClone<T>(T obj)
        {
            return (T)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(obj));
        }
    }
}