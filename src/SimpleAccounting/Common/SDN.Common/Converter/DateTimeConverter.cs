using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SDN.Common.Converter
{
    //public class DateTimeConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        DateTime? selectedDate = value as DateTime?;

    //        if (selectedDate != null)
    //        {
    //            string dateTimeFormat = parameter as string;
    //            return selectedDate.Value.ToString(dateTimeFormat);
    //        }

    //        return "Select Date";
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        try
    //        {

    //            var valor = value as string;
    //            if (!string.IsNullOrEmpty(valor))
    //            {
    //                var retorno = DateTime.Parse(valor);
    //                return retorno;
    //            }

    //            return null;
    //        }
    //        catch
    //        {
    //            return DependencyProperty.UnsetValue;
    //        }
    //    }
    //}

    public class DateTimeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {

            DateTime? selectedDate = values[2] as DateTime?;
            string dateTimeFormat = values[1] as string;
            if(dateTimeFormat==null || dateTimeFormat == string.Empty)
            {
                dateTimeFormat = "dd/MM/yyyy";
            }
            if (selectedDate != null)
            {      
                                             
               return selectedDate.Value.ToString(dateTimeFormat).Replace('-','/');               
            }
            //return "Select Date";
            return dateTimeFormat;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            //try
            //{

            //    var valor = value as string;
            //    if (!string.IsNullOrEmpty(valor))
            //    {
            //        var retorno = DateTime.Parse(valor);
            //        return retorno;
            //    }

            //    return null;
            //}
            //catch
            //{
            //    return DependencyProperty.UnsetValue;
            //}
            return null;
        }
    }
}
