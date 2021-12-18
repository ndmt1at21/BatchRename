using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public class ProjectStore
    {
        public WindowPosition MainWindowPosition { get; set; }
        public WindowPosition DialogSelectRulePosition { get; set; }
        public Dictionary<string, RulePickedModel> PickedRules { get; set; }
        public Dictionary<string, RuleEditingModel> EditingRules { get; set; }
        public Dictionary<string, NodeConvertModel> ConvertNodes { get; set; }
        public string OutputPath { get; set; }

        public static ProjectStore FromStore(Store store)
        {
            return new ProjectStore()
            {
                ConvertNodes = store.ConvertNodes,
                DialogSelectRulePosition = store.DialogSelectRulePosition,
                EditingRules = store.EditingRules,
                MainWindowPosition = store.MainWindowPosition,
                OutputPath = store.OutputPath,
                PickedRules = store.PickedRules
            };
        }
    }
}
