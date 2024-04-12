using Pharma_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_Management_System.Models
{
    public class PMSCat : Category_details
    {
        public virtual IList<Category_details> CatDetails { get; set; }
        public virtual Category_details CatDetail { get; set; }
    }
}