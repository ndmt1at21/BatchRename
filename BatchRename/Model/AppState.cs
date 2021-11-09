using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public class AppState
    {
        public WindowPosition MainWindowPosition { get; set; }
        public WindowPosition DialogSelectRulePosition { get; set; }
        public List<RulePreset> SelectedRules { get; set; }

        public AppState()
        {
            MainWindowPosition = new WindowPosition { Height = 0, Width = 0, Left = 0, Top = 0 };
            DialogSelectRulePosition = new WindowPosition { Height = 0, Width = 0, Left = 0, Top = 0 };
            SelectedRules = new List<RulePreset>();
        }
    }
}