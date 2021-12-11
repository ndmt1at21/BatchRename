using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public enum ConvertStatus
    {
        ERROR,
        SUCCESS
    }

    public class NodeConvertModel
    {
        public Node node { get; set; }
        public ConvertStatus ConvertStatus { get; set; }
        public string Output { get; set; }
    }
}
