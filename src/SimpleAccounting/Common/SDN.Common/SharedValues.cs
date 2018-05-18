﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Common
{
    public class SharedValues
    {
        public static string getValue { get; set; }
        public static string CurrencyName { get; set; }
        public static string decimalPlaces { get; set; }
        public static string NewClick { get; set; }
        public static string CollectCommand { get; set; }
        public static decimal? CustomerDiscount { get; set; }

        public static bool IsIncludeTax { get; set; }
    }
}
