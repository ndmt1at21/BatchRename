using BatchRename.Lib;
using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Commands
{
    public class ImportCommand : CommandBase
    {
        private Store _store { get; set; }
        private LoadService<RulePickedModel> _loadService { get; set; }

        public ImportCommand(Store store, LoadService<RulePickedModel> loadService)
        {
            _store = store;
            _loadService = loadService;
        }

        public override void Execute(object parameter)
        {
            // TODO
        }
    }
}
