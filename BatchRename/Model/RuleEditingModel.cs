using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public class RuleEditingModel
    {
        public string RuleId { get; set; }
        public IRuleParameter Paramter { get; set; }
    }
}
