using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace AddCounterToEndRule
{
    public class AddCounterToEndParamter : IRuleParameter
    {
        public string Id => "AddCounterToEnd";

        public int StartFrom { get; set; }
        public int Step { get; set; }
        public int PartCountLength { get; set; }
        public char PadChar { get; set; }
    }
}
