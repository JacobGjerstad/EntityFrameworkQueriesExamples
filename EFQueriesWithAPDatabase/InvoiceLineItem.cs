namespace EFQueriesWithAPDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvoiceLineItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short InvoiceSequence { get; set; }

        public int AccountNo { get; set; }

        [Column(TypeName = "money")]
        public decimal InvoiceLineItemAmount { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceLineItemDescription { get; set; }

        public virtual GLAccount GLAccount { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
