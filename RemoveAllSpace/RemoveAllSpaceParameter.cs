using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllSpace
{
    public class RemoveAllSpaceParameter : IRuleParameter
    {
        public string Id => "RemoveAllSpaces";


        public bool IsAppendToOriginal { get; set; }
    }
}
