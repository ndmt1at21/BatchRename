using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCounterToEndRule
{
    public class AddCounterToEndConstant
    {
        static public AddCounterToEndParamter DEFAULT_PARAMETER = new AddCounterToEndParamter()
        {
            PartCountLength = 1,
            StartFrom = 1,
            Step = 1,
            PadChar = '0'
        };
    }
}
