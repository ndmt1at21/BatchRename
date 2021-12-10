using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BatchRename.Lib
{
    public class BreakpointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float fValue;

            if (float.TryParse(value.ToString(), out fValue))
            {
                if (fValue >= 1920)
                    return "ExtraLarge";

                if (fValue >= 1200)
                    return "Large";

                if (fValue >= 992)
                    return "Normal";

                if (fValue >= 768)
                    return "Medium";

                if (fValue >= 600)
                    return "Small";
            }

            return "Small";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine("In Convert Back");
            return value;
        }
    }
}
