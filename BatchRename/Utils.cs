using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BatchRename
{
    public static class Utils
    {
        public static FileInfo[] GetDllFilesFromFolder(String folderPath)
        {
            DirectoryInfo d = new DirectoryInfo(@folderPath);
            FileInfo[] files = d.GetFiles("*.dll", SearchOption.AllDirectories);

            return files;
        }

        public static Object CreateInstanceFromDllFile(String dllPath, Type targetType, Object[] argsForInstance = null)
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

        public static T DeepClone<T>(T obj)
        {
            return (T)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(obj));
        }

        public static void RenameFile(string currentPath, string newFileName)
        {
            FileInfo file = new FileInfo(currentPath);

            if (file.Exists)
            {
                try
                {
                    var groups = Regex.Match(currentPath, @"^(.+)[\/\\]([^\/]+)$").Groups;

                    if (groups.Count != 3)
                        throw new NotSupportedException();

                    file.MoveTo(@$"{groups[1]}\{newFileName}");
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}