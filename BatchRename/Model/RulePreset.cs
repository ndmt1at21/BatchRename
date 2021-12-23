using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public class RulePreset
    {
        public IEnumerable<RulePickedModel> PickedRules { get; set; }
    }
}
