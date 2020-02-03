using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQueriesWithAPDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            APContext db = new APContext();

            // Get all Vendors in California
            List<Vendor> caVendors = (from v in db.Vendors
                                      where v.VendorState == "CA"
                                      orderby v.VendorName
                                      select v).ToList();

            Console.WriteLine("**** Vendors in CA ****");
            foreach (Vendor currVendor in caVendors)
            {
                Console.WriteLine(currVendor.VendorName);
            }

            // Retrieve a single object
            Console.WriteLine("\n\n\n**** Single Object ****");

            Vendor singleVendor =  (from vendor in db.Vendors
                                  where vendor.VendorName == "IBM"
                                  select vendor).SingleOrDefault();

            if(singleVendor != null)
            {
                Console.WriteLine(singleVendor.VendorName);
            }
            else
            {
                Console.WriteLine("Vendor not found");
            }

            // Get all Vendors and their Invoices (Join)
            Console.WriteLine("\n\n\n**** Vendors and Invoices ****");

            List<Vendor> vendorAndInvoices = (from v in db.Vendors
                                              select v).Include(v => v.Invoices)
                                                       //.Include("Invoices")
                                                       //.Include(nameof(Vendor.Invoices))
                                                       .ToList();

            foreach (Vendor vendor in vendorAndInvoices)
            {
                Console.WriteLine(vendor.VendorName);
                foreach (Invoice inv in vendor.Invoices)
                {
                    Console.WriteLine("\t" + inv.InvoiceNumber);
                }
            }

            // Performs an inner join but dont want a vendor for each invoice
            var vendorAndInvoices2 = (from v in db.Vendors
                                               join i in db.Invoices
                                               on v.VendorID equals i.VendorID
                                               select new 
                                               {
                                                   v.VendorName, // using inferred name
                                                   Invoices = v.Invoices
                                               }).ToList();

            foreach (var vendor in vendorAndInvoices2)
            {
                Console.WriteLine(vendor.VendorName);
                foreach (Invoice inv in vendor.Invoices)
                {
                    Console.WriteLine("\t" + inv.InvoiceNumber);
                }
            }

            // Retrieve object(s) but limit columns
            // Get Vendors and only location info (name/city/state)
            // SELECT VendorName AS Name, VendorCity AS City, VendorState AS State
            Console.WriteLine("\n\n\n**** Vendors Name/City/State ****");

            List<VendorLoc> vendorLocations = (from v in db.Vendors
                                   select new VendorLoc
                                   {
                                       Name = v.VendorName,
                                       City = v.VendorCity,
                                       State = v.VendorState
                                   }).ToList();

            foreach (VendorLoc venLocation in vendorLocations)
            {
                Console.WriteLine($"{venLocation.Name} " +
                                  $"{venLocation.City} " +
                                  $"{venLocation.State}");
            }


            // Get sum of all invoice totals
            Console.WriteLine("\n\n\n****Invoice Total****");

            double totalInvoiceTotal = (double)(from inv in db.Invoices
                                        select inv.InvoiceTotal).Sum();

            Console.WriteLine("Invoice Total: " + totalInvoiceTotal);

           Console.ReadKey();

        }
    }

    class VendorLoc
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
