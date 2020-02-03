namespace EFQueriesWithAPDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class APContext : DbContext
    {
        public APContext()
            : base("name=APContext")
        {
        }

        public virtual DbSet<GLAccount> GLAccounts { get; set; }
        public virtual DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GLAccount>()
                .Property(e => e.AccountDescription)
                .IsUnicode(false);

            modelBuilder.Entity<GLAccount>()
                .HasMany(e => e.InvoiceLineItems)
                .WithRequired(e => e.GLAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GLAccount>()
                .HasMany(e => e.Vendors)
                .WithRequired(e => e.GLAccount)
                .HasForeignKey(e => e.DefaultAccountNo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceLineItem>()
                .Property(e => e.InvoiceLineItemAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InvoiceLineItem>()
                .Property(e => e.InvoiceLineItemDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.InvoiceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.InvoiceTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.PaymentTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.CreditTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Term>()
                .Property(e => e.TermsDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Term>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Term)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Term>()
                .HasMany(e => e.Vendors)
                .WithRequired(e => e.Term)
                .HasForeignKey(e => e.DefaultTermsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorAddress1)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorAddress2)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorCity)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorState)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorContactLName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorContactFName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);
        }
    }
}
