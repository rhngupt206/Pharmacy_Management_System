using Pharma_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_Management_System.Models
{
    public class PMSSeller : Seller_details
    {
        public virtual IList<Seller_details> SellerDetails { get; set; }
        public virtual Seller_details SellerDetail { get; set; }
    }
    public enum gender
    {
        Male,Female
    }
}