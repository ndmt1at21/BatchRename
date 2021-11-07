using BatchRename.Store;
using System;

namespace BatchRename
{
    public class WindowStore : StoreBase
    {
        public Double Width { get; set; }
        public Double Height { get; set; }
        public Double Left { get; set; }
        public Double Top { get; set; }
    }
}