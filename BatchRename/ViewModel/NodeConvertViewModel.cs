using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.ViewModel
{
    public class NodeConvertViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public bool IsMarked { get; set; }
        public NodeViewModel Node { get; set; }
        public ConvertStatus ConvertStatus { get; set; }
        public string OutputPath { get; set; }
    }
}
