//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDN.ProductEDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesInvoice()
        {
            this.SalesInvoiceDetails = new HashSet<SalesInvoiceDetail>();
        }
    
        public int ID { get; set; }
        public string SI_No { get; set; }
        public System.DateTime SI_Date { get; set; }
        public Nullable<int> SI_Credit_Days { get; set; }
        public string Cus_PO_No { get; set; }
        public Nullable<int> Salesman { get; set; }
        public Nullable<bool> Exc_Inc_GST { get; set; }
        public int Cus_Id { get; set; }
        public Nullable<decimal> SI_Tot_bef_Tax { get; set; }
        public Nullable<decimal> SI_GST_Amt { get; set; }
        public Nullable<decimal> SI_Tot_aft_Tax { get; set; }
        public string SI_TandC { get; set; }
        public Nullable<byte> SI_Status { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesInvoiceDetail> SalesInvoiceDetails { get; set; }
    }
}
