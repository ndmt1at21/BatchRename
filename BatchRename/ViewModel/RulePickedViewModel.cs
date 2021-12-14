using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatchRename.Model;

namespace BatchRename.ViewModel
{
    public class RulePickedViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public bool IsMarked { get; set; }
        public string RuleName { get; set; }
        public string Statement { get; set; }
    }
}
