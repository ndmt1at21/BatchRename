using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public class Node
    {
        public string Path { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
    }
}