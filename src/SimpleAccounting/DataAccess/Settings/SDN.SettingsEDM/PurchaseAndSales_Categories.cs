//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDN.SettingsEDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseAndSales_Categories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseAndSales_Categories()
        {
            this.PurchaseAndSales_CategoriesContent = new HashSet<PurchaseAndSales_CategoriesContent>();
        }
    
        public int ID { get; set; }
        public string Cat_Name { get; set; }
        public string Cat_Code { get; set; }
        public string Content_Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseAndSales_CategoriesContent> PurchaseAndSales_CategoriesContent { get; set; }
    }
}