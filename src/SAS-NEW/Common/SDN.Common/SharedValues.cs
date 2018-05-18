﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static int StockType { get; set; }
        public static string  Print_Id { get; set; }
        public static string PrintDate { get; set; }
        public static int Print_Type { get; set; }
        public static string ViewName { get; set; }
        public static string ScreenCheckName { get; set; }
        public static string JsonDataValues { get; set; }
        public static IEnumerable<int> CustomersID { get; set; }
        public static IEnumerable<int> SupplierID { get; set; }
        public static IEnumerable<object> UserList { get; set; }
        public static string CurrentDataBase { get; set; }
        public static bool IsSave { get; set; }
        public static int SelectedCusId { get; set; }
        public static int SelectedSupId { get; set; }
        public static string OldDatabase{ get; set; }
    }
}