using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Common
{
    public static class Utility
    {
        public static double CalculatePercentage(double number, double percentage)
        {
            return (number * percentage) / 100;
        }
        public static decimal? CalculatePercentage(decimal? number, decimal? percentage)
        {
            if (number == null || percentage == null)
            {
                return 0;
            }
            else
            {
                return (number * percentage) / 100;
            }
        }

        public static decimal? CalculateAverage(decimal? Component, int number)
        {
            if (number != 0 && Component!=0)
            {
                return Component / number;
            }
            else
            {
                return 0;
            }
        }
        public static DateTime SimpleDateTime(string date)
        {
            var ci = new CultureInfo("en-US");
            var formats = new[] { "M-d-yyyy", "dd-MM-yyyy", "MM-dd-yyyy", "M.d.yyyy", "dd.MM.yyyy", "MM.dd.yyyy", "dd/MM/yy", "MM/dd/yy" }
                    .Union(ci.DateTimeFormat.GetAllDateTimePatterns()).ToArray();
            return DateTime.ParseExact(date, formats, ci, DateTimeStyles.AssumeLocal);

        }
    }
}
