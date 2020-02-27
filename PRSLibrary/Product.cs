using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PRSLibrary {
    public class Product {

        public int Id { get; set; }
        public string PartNbr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string PhotoPath { get; set; }
        public int VendorId { get; set; }

        public virtual List<RequestLine> RequestLines { get; set; }
        public virtual List<Vendor> Vendors { get; set; }
        
        public Product() {

        }

    }
}
