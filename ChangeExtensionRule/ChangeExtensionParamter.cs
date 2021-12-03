using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContract;

namespace ChangeExtensionRule
{
    public class ChangeExtensionParamter : IRuleParameter
    {
        public string Id => "ChangeExtensionParamter";

        public string NewExtension;
    }
}