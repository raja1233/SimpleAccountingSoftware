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
    
    public partial class AdjustedDebitNoteDetail
    {
        public int ID { get; set; }
        public Nullable<int> ADN_ID { get; set; }
        public string PurchaseInvoiceNo { get; set; }
        public Nullable<System.DateTime> PurchaseInvoiceDate { get; set; }
        public Nullable<System.DateTime> PaymentDueDate { get; set; }
        public Nullable<decimal> PurchaseInvoiceAmount { get; set; }
        public Nullable<decimal> AmountDue { get; set; }
        public Nullable<decimal> AmountAdjusted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual AdjustedDebitNote AdjustedDebitNote { get; set; }
    }
}
