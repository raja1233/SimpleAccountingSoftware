//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SASDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseOrderDetail
    {
        public int ID { get; set; }
        public int PO_ID { get; set; }
        public string PO_No { get; set; }
        public string PandS_Code { get; set; }
        public string PandS_Name { get; set; }
        public Nullable<int> PO_Qty { get; set; }
        public Nullable<decimal> PO_Price { get; set; }
        public Nullable<decimal> PO_Amount { get; set; }
        public Nullable<decimal> PO_Discount { get; set; }
        public string GST_Code { get; set; }
        public Nullable<decimal> GST_Rate { get; set; }
    
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}