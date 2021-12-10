using BatchRename.Themes.CustomControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BatchRename.Lib
{
    public class CompareSelectedAndAllItemToBoolCpnverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine("Type::" + values[0].GetType());
            int nSelected = (int)values[0];
            int allItemsCount = (int)values[1];

            if (nSelected == 0)
                return false;

            if (nSelected == allItemsCount)
                return true;

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Debug.WriteLine(value);
            return new object[] { 0, 1 };
        }
    }
}
