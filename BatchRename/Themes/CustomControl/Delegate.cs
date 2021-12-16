using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Themes.CustomControl
{
    public delegate void MarkChangedEventHandler(string markId);
    public delegate void SelectionChangedEventHandler(IEnumerable<string> selectedIds);
}
