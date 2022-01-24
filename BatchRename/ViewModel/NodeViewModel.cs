using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.ViewModel
{
    public class NodeViewModel : BaseViewModel
    {
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
    }
}
