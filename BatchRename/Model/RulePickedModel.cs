using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace BatchRename.Model
{
    public class RulePickedModel
    {
        public string Id { get; set; }
        public long Position { get; set; }
        public string RuleId { get; set; }
        public IRuleParameter Paramter { get; set; }
    }
}
