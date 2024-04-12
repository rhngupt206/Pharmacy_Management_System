using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharma_Library
{
    public class clsseller
    {
        public static bool UpdateStock(string MedCode, int FinalQty)
        {

            using (var ctx = new Pharmacy_Management_SystemEntities2())
            {
                var med = ctx.Med_details.Where(a => a.MedCode == MedCode).SingleOrDefault();
                
                med.MedStock = FinalQty;
                ctx.Entry(med).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }
        public static int SaveBill(Billing_details bed)
        {
            using (var ctx = new Pharmacy_Management_SystemEntities2())
            {
                ctx.Billing_details.Add(bed);
                ctx.SaveChanges();
                return bed.BillId;
            }
        }
    }
   
}
