using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Lib
{
    public interface IPersister
    {
        void Save(string path, object data);
        object Load(string path);
        Task SaveAsync(string path, object data);
        void Delete(string path);
    }
}
