using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace BatchRename.Model
{
    public class RulePickedUpdateModel
    {
		public string Id { get; set; }
        public bool? IsMarked { get; set; }
        public long? Position { get; set; }
        public IRuleParameter Paramter { get; set; }

        public RulePickedUpdateModel Clone()
        {
            return new RulePickedUpdateModel()
            {
                Id = Id,
                IsMarked = IsMarked,
                Position = Position,
                Paramter = Paramter
            };
        }
    }
}
