using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Commands.Files
{
    public class RemoveFileCommand : CommandBase
    {
        private Store _store { get; set; }

        public RemoveFileCommand(Store store)
        {
            _store = store;
        }

        public override void Execute(object parameter)
        {
            IEnumerable<string> selectedIds = (IEnumerable<string>)parameter;

            if (selectedIds == null)
                return;

            foreach (var id in selectedIds)
            {
                _store.DeleteNodeConvert(id);
                Debug.WriteLine(id);
            }
        }
    }
}
