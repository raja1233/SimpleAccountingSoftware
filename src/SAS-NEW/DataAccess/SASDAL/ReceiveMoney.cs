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
    
    public partial class ReceiveMoney
    {
        public int ID { get; set; }
        public Nullable<int> LinkedAccountID { get; set; }
        public Nullable<int> CashBankAccountID { get; set; }
        public string CashChequeNo { get; set; }
        public Nullable<System.DateTime> CashChequeDate { get; set; }
        public Nullable<bool> IsCheque { get; set; }
        public Nullable<decimal> TotalBeforeTax { get; set; }
        public Nullable<decimal> TotalAfterTax { get; set; }
        public Nullable<decimal> TotalTax { get; set; }
        public Nullable<int> TaxID { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
