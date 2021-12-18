using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace BatchRename.ViewModel
{
    public class EditingRuleViewModel
    {
        public string RuleId { get; set; }
        public string Name { get; set; }
        public IRuleComponent Component { get; set; }
    }
}
