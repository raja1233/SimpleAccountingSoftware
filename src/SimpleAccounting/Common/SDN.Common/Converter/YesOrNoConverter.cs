using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDN.Common.Converter
{
    using System.Windows.Data;
    using System.Globalization;
    public class YesNoBoolConverter : IValueConverter
    {
         
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString() == "Y")
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "Y";
                else
                    return "N";
            }
            return null;
        }

    }
   
}
