using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceCharacter
{
    public class ReplaceCharacterParameter : IRuleParameter
    {
        public string Id => "ReplaceCharacter";

        public string oldChar { get; set; }
        public string newChar { get; set; }
    }
}
