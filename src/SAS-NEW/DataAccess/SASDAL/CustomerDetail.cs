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
    
    public partial class CustomerDetail
    {
        public int ID { get; set; }
        public int Cus_Id { get; set; }
        public string Cus_Name { get; set; }
        public string Cus_Inactive { get; set; }
        public string Cus_Company_Reg_no { get; set; }
        public Nullable<int> Cus_Type { get; set; }
        public Nullable<int> Cus_Salesman { get; set; }
        public Nullable<int> Cus_Credit_Limit_Days { get; set; }
        public Nullable<int> Cus_Credit_Limit_Amount { get; set; }
        public Nullable<int> Cus_Discount { get; set; }
        public string Cus_Telephone { get; set; }
        public string Cus_Fax { get; set; }
        public string Cus_Email { get; set; }
        public string Cus_Contact_Person { get; set; }
        public string Cus_GST_Reg_No { get; set; }
        public Nullable<bool> Cus_Charge_GST { get; set; }
        public string Cus_Remarks { get; set; }
        public string Cus_Bill_to_line1 { get; set; }
        public string Cus_Bill_to_line2 { get; set; }
        public string Cus_Bill_to_city { get; set; }
        public string Cus_Bill_to_state { get; set; }
        public string Cus_Bill_to_country { get; set; }
        public string Cus_Bill_to_post_code { get; set; }
        public string Cus_Ship_to_line1 { get; set; }
        public string Cus_Ship_to_line2 { get; set; }
        public string Cus_Ship_to_city { get; set; }
        public string Cus_Ship_to_state { get; set; }
        public string Cus_Ship_to_country { get; set; }
        public string Cus_Ship_to_post_code { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<decimal> Cus_Balance { get; set; }
    }
}
