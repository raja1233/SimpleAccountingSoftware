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
    
    public partial class TopPand
    {
        public int ID { get; set; }
        public Nullable<byte> Year { get; set; }
        public Nullable<byte> Quarter { get; set; }
        public Nullable<byte> Month { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public string PandS_Cat1 { get; set; }
        public string PandS_Cat2 { get; set; }
        public string PandS_Code { get; set; }
        public string PandS_Name { get; set; }
        public Nullable<decimal> Sales_Amt { get; set; }
        public Nullable<decimal> Sales_Per { get; set; }
        public Nullable<decimal> Purchase_Amt { get; set; }
        public Nullable<decimal> Purchase_Per { get; set; }
        public Nullable<decimal> Profit_Amt { get; set; }
        public Nullable<decimal> Profit_Per { get; set; }
        public Nullable<bool> Inc_GST { get; set; }
        public string PandS_Type { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}