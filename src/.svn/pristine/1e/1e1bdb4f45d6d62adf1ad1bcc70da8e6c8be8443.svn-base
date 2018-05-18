using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDN.Common.Converter
{
    using System.Globalization;
    using System.Windows.Data;
    public class EmptyIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (int)value == default(int))
                return "";

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(value as string))
                return default(int);

            return int.Parse(value.ToString());
        }
    }
}
