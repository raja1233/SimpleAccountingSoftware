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
    
    public partial class AdjustedCreditNote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdjustedCreditNote()
        {
            this.AdjustedCreditNoteDetails = new HashSet<AdjustedCreditNoteDetail>();
        }
    
        public int ID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string CreditNoteNumber { get; set; }
        public Nullable<System.DateTime> CreditNoteDate { get; set; }
        public Nullable<decimal> CreditNoteAmount { get; set; }
        public string AdjustCreditNoteNumber { get; set; }
        public Nullable<System.DateTime> AdjustCreditNoteDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjustedCreditNoteDetail> AdjustedCreditNoteDetails { get; set; }
    }
}
