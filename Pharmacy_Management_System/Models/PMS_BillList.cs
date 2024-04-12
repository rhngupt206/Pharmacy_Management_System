using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Pharmacy_Management_System.Models
{
    public class PMS_BillList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public int Total { get; set; }
    }
}