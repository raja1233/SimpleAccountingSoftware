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
    
    public partial class CashAndBankTransaction
    {
        public int ID { get; set; }
        public Nullable<int> Cus_Sup_Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<int> Acc_Id { get; set; }
        public Nullable<bool> Is_Cheque { get; set; }
        public string Cash_Cheque_No { get; set; }
        public Nullable<System.DateTime> Cash_Cheque_Date { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Remarks { get; set; }
        public string Cheque_Photo { get; set; }
        public string SO_CN_PO_DN_No { get; set; }
        public Nullable<System.DateTime> SO_CN_PO_DN_Date { get; set; }
        public Nullable<decimal> SO_CN_PO_DN_Amt { get; set; }
        public Nullable<decimal> Amt_Due { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Amt_Refunded { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string DN_CN_No { get; set; }
        public string AD_AC_NO { get; set; }
    }
}
