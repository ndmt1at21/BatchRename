using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Model
{
    public class WindowPosition
    {
        public double Left;
        public double Top;
        public double Width;
        public double Height;

        public WindowPosition Clone()
        {
            return new WindowPosition
            {
                Left = this.Left,
                Top = this.Top,
                Width = this.Width,
                Height = this.Height
            };
        }
    }
}