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
    
    public partial class AccountsTransaction
    {
        public int ID { get; set; }
        public Nullable<int> Acc_Id { get; set; }
        public string Trans_Type { get; set; }
        public string Name { get; set; }
        public string No { get; set; }
        public Nullable<System.DateTime> Trans_Date { get; set; }
        public Nullable<decimal> Trans_Amount { get; set; }
        public Nullable<System.DateTime> Year_to_Date { get; set; }
        public Nullable<decimal> Opening_Balance { get; set; }
        public Nullable<decimal> Closing_Balance { get; set; }
        public string In_Active { get; set; }
        public string Invoice_Type { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}
