using PluginContract;
using System;

namespace BatchRename.Model
{
    public class RuleData
    {
        public String RuleId { get; set; }
        public String Name { get; set; }
        public RuleParameter paramter { get; set; }
    }
}