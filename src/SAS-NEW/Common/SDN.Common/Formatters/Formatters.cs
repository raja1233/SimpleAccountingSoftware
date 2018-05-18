using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Common.Formatters
{
    using System.Globalization;
    static public class Formatters
    {
       public static string CurrencyToIntegerConvertor(string currency, string cultureInfo)
        {
            var culture = CultureInfo.GetCultureInfo(cultureInfo);
            var numberFormat = (NumberFormatInfo)culture.NumberFormat.Clone();
            // Force the currency symbol regardless of culture
            string formatter = string.Empty;
            currency = currency.Replace(numberFormat.CurrencySymbol, "");
            string[] str = currency.Split(',');
            foreach (var t in str)
            {
                formatter += t;
            }
            return formatter;
        }

        public static bool IsCompanyRegistered()
        {

            return true;
        }
    }
}
