using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingExceptions
{
    public class CheckingExceptionsParameter : IRuleParameter
    {
        public string Id => "CheckingExceptions";

        public string CheckingExceptions;
    }
}
