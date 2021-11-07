﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PluginContract;
using BatchRename;

namespace BatchRename.Factory
{
    public class PluginManager
    {
        static private Dictionary<String, IRulePlugin> prototype { get; set; }

        private static PluginManager shared;

        public static PluginManager Shared { get; }

        private PluginManager()
        {
            prototype = new Dictionary<string, IRulePlugin>();
        }

        static public void Load(String path)
        {
            prototype.Clear();

            if (shared == null)
                shared = new PluginManager();

            FileInfo[] files = Utils.GetDllFilesFromFolder(path);

            foreach (FileInfo file in files)
            {
                IRulePlugin plugin = (IRulePlugin)Utils.CreateInstanceFromDllFile(file.FullName, typeof(IRulePlugin));

                if (plugin == null)
                    continue;

                prototype.Add(plugin.ID, plugin);
            }
        }

        public String[] GetPluginIDs()
        {
            return prototype.Keys.ToArray();
        }

        public IRuleComponent CreateRuleComponent(String id)
        {
            if (prototype[id] == null)
                return null;

            return prototype[id].CreateComponentInstance();
        }

        public IRuleComponent CreateRuleComponent(String id, RuleParameter parameter)
        {
            if (prototype[id] == null)
                return null;

            return prototype[id].CreateComponentInstance(parameter);
        }

        public IRuleComponent CreateRuleComponent(String id, String serializeParamter)
        {
            if (prototype[id] == null)
                return null;

            return prototype[id].CreateComponentInstance(serializeParamter);
        }

        public IRenameRule CreateRule(String id)
        {
            if (prototype[id] == null)
                return null;

            return prototype[id].CreateRuleInstance();
        }
    }
}