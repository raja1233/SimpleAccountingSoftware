//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDN.CashBank.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class CashAndBankStatement
    {
        public int ID { get; set; }
        public Nullable<int> Acc_Id { get; set; }
        public string Acc_Name { get; set; }
        public Nullable<byte> Year { get; set; }
        public Nullable<byte> Quarter { get; set; }
        public Nullable<byte> Month { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public string Name { get; set; }
        public string Cash_Cheq_No { get; set; }
        public Nullable<System.DateTime> Cash_Cheq_Date { get; set; }
        public Nullable<decimal> Deposit { get; set; }
        public Nullable<decimal> Withdrawal { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}
