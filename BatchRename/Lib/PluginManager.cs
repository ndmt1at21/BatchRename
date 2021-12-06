using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PluginContract;
using BatchRename;
using Utils;
using System.Windows;

namespace BatchRename.Lib
{
    public class PluginManager
    {
        static private Dictionary<string, IRulePlugin> prototype { get; set; } =
            new Dictionary<string, IRulePlugin>();

        private static PluginManager shared;

        public static PluginManager Shared
        {
            get
            {
                if (shared == null)
                    shared = new PluginManager();
                return shared;
            }
        }

        private PluginManager()
        {
        }

        static public void Load(string path)
        {
            prototype.Clear();

            if (shared == null)
                shared = new PluginManager();

            FileInfo[] files = Utils
                .Dll
                .GetDllFilesFromFolder(path)
                .Where(file => file.Directory.Name != "ref").ToArray();

            foreach (FileInfo file in files)
            {
                IRulePlugin plugin = (IRulePlugin)Utils.Dll.CreateInstanceFromDllFile(file.FullName, typeof(IRulePlugin));

                if (plugin == null)
                    continue;

                if (!prototype.ContainsKey(plugin.Id))
                    prototype.Add(plugin.Id, plugin);
            }
        }

        public string[] GetPluginIDs()
        {
            return prototype.Keys.ToArray();
        }

        public IRuleComponent CreateRuleComponent(string id)
        {
            if (prototype[id] == null)
                return null;

            return prototype[id].CreateComponentInstance();
        }

        public IRuleComponent CreateRuleComponent(string id, IRuleParameter parameter)
        {
            if (prototype[id] == null)
                return null;

            var instance = prototype[id].CreateComponentInstance();
            instance.SetRuleParameter(parameter);

            return instance;
        }

        //public IRuleComponent CreateRuleComponent(string id, string serializeParamter)
        //{
        //    if (prototype[id] == null)
        //        return null;

        //    return prototype[id].CreateComponentInstance(serializeParamter);
        //}

        public IRenameRule CreateRule(string id)
        {
            if (prototype[id] == null)
                return null;

            return prototype[id].CreateRuleInstance();
        }

        public string GetRuleName(string id)
        {
            if (prototype[id] == null)
                return null;

            return prototype[id].Name;
        }
    }
}