//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDN.Sales.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductsAndService
    {
        public int ID { get; set; }
        public string PandS_Type { get; set; }
        public string PandS_Inactive { get; set; }
        public string PandS_Code { get; set; }
        public string PandS_Name { get; set; }
        public Nullable<int> PandS_Cat1 { get; set; }
        public Nullable<int> PandS_Cat2 { get; set; }
        public string PandS_Description { get; set; }
        public Nullable<int> Income_Account { get; set; }
        public Nullable<int> Cost_Account { get; set; }
        public Nullable<int> Asset_Account { get; set; }
        public Nullable<int> Tax_ID { get; set; }
        public Nullable<decimal> Tax_Rate { get; set; }
        public Nullable<decimal> PandS_Std_Sell_Price_bef_GST { get; set; }
        public Nullable<decimal> PandS_Std_Sell_Price_aft_GST { get; set; }
        public Nullable<decimal> PandS_Ave_Sell_Price_bef_GST { get; set; }
        public Nullable<decimal> PandS_Ave_Sell_Price_aft_GST { get; set; }
        public Nullable<decimal> PandS_Last_Sold_Price_bef_GST { get; set; }
        public Nullable<decimal> PandS_Last_Sold_Price_aft_GST { get; set; }
        public Nullable<decimal> PandS_Std_Cost_Price_bef_GST { get; set; }
        public Nullable<decimal> PandS_Std_Cost_Price_aft_GST { get; set; }
        public Nullable<decimal> PandS_Ave_Cost_Price_bef_GST { get; set; }
        public Nullable<decimal> PandS_Ave_Cost_Price_aft_GST { get; set; }
        public Nullable<decimal> PandS_Last_Pur_Price_bef_GST { get; set; }
        public Nullable<decimal> PandS_Last_Pur_Price_aft_GST { get; set; }
        public Nullable<int> PandS_Min_Qty { get; set; }
        public Nullable<int> PandS_Qty_in_stock { get; set; }
        public Nullable<int> PandS_Qty_for_SO { get; set; }
        public Nullable<int> PandS_Qty_on_PO { get; set; }
        public Nullable<decimal> PandS_Stock_Value { get; set; }
        public byte[] PandS_Stock_Picture { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsRefresh { get; set; }
        public Nullable<System.DateTime> RefreshDate { get; set; }
    }
}
