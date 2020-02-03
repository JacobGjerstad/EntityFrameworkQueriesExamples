namespace EFQueriesWithAPDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
        }

        public int InvoiceID { get; set; }

        public int VendorID { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "money")]
        public decimal InvoiceTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal PaymentTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal CreditTotal { get; set; }

        public int TermsID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime InvoiceDueDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PaymentDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }

        public virtual Term Term { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
