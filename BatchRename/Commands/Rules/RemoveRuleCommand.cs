using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BatchRename.Commands.Rules
{
    public class RemoveRuleCommand : CommandBase
    {
        private Store _store { get; set; }

        public RemoveRuleCommand(Store store)
        {
            _store = store;
        }

        public override void Execute(object parameter)
        {
            IEnumerable<string> selectedIds = (IEnumerable<string>)parameter;

            if (selectedIds == null)
                return;

            foreach (var id in selectedIds)
                _store.DeletePickedRule(id);
        }
    }
}
