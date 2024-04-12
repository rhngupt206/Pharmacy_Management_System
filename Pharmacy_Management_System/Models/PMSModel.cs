using Pharma_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacy_Management_System.Models
{
    public class PMSModel : Med_details
    {
        public virtual IList<Med_details> MedDetails { get; set; }
        public virtual Med_details MedDetail { get; set; }
        public int MedQty { get; set; }
        [DataType(DataType.Date)]
        public DateTime BillDate { get; set; }
        public virtual IList<PMS_BillList> BillLists { get; set; }
        public virtual PMS_BillList BillList { get; set; }
    }
}