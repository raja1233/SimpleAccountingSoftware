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
    
    public partial class UndeliveredPurchaseOrdersWithDeposit
    {
        public int ID { get; set; }
        public Nullable<int> S_ID { get; set; }
        public string UPurchaseOrder_No { get; set; }
        public Nullable<System.DateTime> UPurchaseOrder_Date { get; set; }
        public Nullable<decimal> UPurchaseOrder_Amount { get; set; }
        public Nullable<decimal> UPurchaseOrderDeposit_Amount { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
