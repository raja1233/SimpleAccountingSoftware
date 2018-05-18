//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDN.Sales.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesQuotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesQuotation()
        {
            this.SalesQuotationDetails = new HashSet<SalesQuotationDetail>();
        }
    
        public int ID { get; set; }
        public string SQ_No { get; set; }
        public System.DateTime SQ_Date { get; set; }
        public Nullable<int> SQ_Valid_for { get; set; }
        public Nullable<int> Salesman { get; set; }
        public Nullable<bool> Exc_Inc_GST { get; set; }
        public int Cus_Id { get; set; }
        public Nullable<int> Ship_to_address { get; set; }
        public Nullable<decimal> SQ_Tot_bef_Tax { get; set; }
        public Nullable<decimal> SQ_GST_Amt { get; set; }
        public Nullable<decimal> SQ_Tot_aft_Tax { get; set; }
        public string SQ_TandC { get; set; }
        public Nullable<bool> SQ_Conv_to_SO { get; set; }
        public Nullable<bool> SQ_Conv_to_SI { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesQuotationDetail> SalesQuotationDetails { get; set; }
    }
}
