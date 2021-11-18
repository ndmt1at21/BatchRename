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
        public int Start { get; set; }
        public int Step { get; set; }
        public int TargetLength { get; set; }
        public string PadString { get; set; }
        public bool PadStart { get; set; }
        public bool PadEnd { get; set; }
    }
}
