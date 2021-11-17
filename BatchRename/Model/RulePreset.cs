using PluginContract;
using System;

namespace BatchRename.Model
{
    public class RulePreset
    {
        public string RuleId { get; set; }
        public IRuleParameter Paramter { get; set; }
    }
}