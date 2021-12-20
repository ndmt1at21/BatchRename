using BatchRename.Lib;
using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Commands
{
    public class ExportCommand : CommandBase
    {
        private Store _store { get; set; }
        private SaveService<RulePickedModel> _saveService { get; set; }

        public ExportCommand(Store store, SaveService<RulePickedModel> saveService)
        {
            _store = store;
            _saveService = saveService;
        }

        public override void Execute(object parameter)
        {
            // TODO
        }
    }
}
