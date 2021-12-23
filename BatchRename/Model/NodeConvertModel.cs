using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public enum ConvertStatus
    {
        ERROR,
        PENDING,
        SUCCESS
    }

    public class NodeConvertModel
    {
        public string Id { get; set; }
        public bool IsMarked { get; set; }
        public Node Node { get; set; }
        public string NewName { get; set; }
        public ConvertStatus ConvertStatus { get; set; }

        public NodeConvertModel Clone()
        {
            return new NodeConvertModel
            {
                Id = Id,
                IsMarked = IsMarked,
                ConvertStatus = ConvertStatus,
                Node = Node.Clone(),
                NewName = NewName,
            };
        }
    }
}
