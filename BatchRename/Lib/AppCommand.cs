using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BatchRename.Lib
{
    public static class AppCommands
    {
        public static readonly RoutedUICommand Import = new RoutedUICommand
            (
                "Import",
                "Import",
                typeof(AppCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.I, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand Export = new RoutedUICommand
            (
                "Export",
                "Export",
                typeof(AppCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.E, ModifierKeys.Control)
                }
            );
    }
}
