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
    
    public partial class CashAndBankHistory
    {
        public int ID { get; set; }
        public Nullable<int> Acc_Id { get; set; }
        public string Acc_Name { get; set; }
        public Nullable<byte> Year1 { get; set; }
        public Nullable<byte> Year2 { get; set; }
        public Nullable<byte> Quater { get; set; }
        public Nullable<decimal> Col1_Amt { get; set; }
        public Nullable<decimal> Col2_Amt { get; set; }
        public Nullable<decimal> Col3_Amt { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}