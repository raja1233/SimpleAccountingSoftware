//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDN.Customers.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesQuotationDetail
    {
        public int ID { get; set; }
        public int SQ_ID { get; set; }
        public string SQ_No { get; set; }
        public string PandS_Code { get; set; }
        public string PandS_Name { get; set; }
        public Nullable<int> SQ_Qty { get; set; }
        public Nullable<decimal> SQ_Price { get; set; }
        public Nullable<decimal> SQ_Amount { get; set; }
        public Nullable<decimal> SQ_Discount { get; set; }
        public string GST_Code { get; set; }
        public Nullable<decimal> GST_Rate { get; set; }
    
        public virtual SalesQuotation SalesQuotation { get; set; }
    }
}