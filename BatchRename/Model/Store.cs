using BatchRename.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Store
{
    public class Store
    {
        private static AppState state { get; set; }

        public static AppState State
        {
            get
            {
                if (state == null)
                    state = new AppState();
                return state;
            }
            set
            {
                state = value;
            }
        }

        private Store()
        {
        }
    }
}