namespace EFQueriesWithAPDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendor()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int VendorID { get; set; }

        [Required]
        [StringLength(50)]
        public string VendorName { get; set; }

        [StringLength(50)]
        public string VendorAddress1 { get; set; }

        [StringLength(50)]
        public string VendorAddress2 { get; set; }

        [Required]
        [StringLength(50)]
        public string VendorCity { get; set; }

        [Required]
        [StringLength(2)]
        public string VendorState { get; set; }

        [Required]
        [StringLength(20)]
        public string VendorZipCode { get; set; }

        [StringLength(50)]
        public string VendorPhone { get; set; }

        [StringLength(50)]
        public string VendorContactLName { get; set; }

        [StringLength(50)]
        public string VendorContactFName { get; set; }

        public int DefaultTermsID { get; set; }

        public int DefaultAccountNo { get; set; }

        public virtual GLAccount GLAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual Term Term { get; set; }
    }
}
