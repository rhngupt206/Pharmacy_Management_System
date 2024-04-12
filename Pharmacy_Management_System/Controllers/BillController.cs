using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharma_Library;
using Pharmacy_Management_System.Models;

namespace Pharmacy_Management_System.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill

        public ActionResult Index(int? id)
        {
            PMSModel model = new PMSModel();

            if (id == null)
            {
                IList<PMS_BillList> PMSBL = new List<PMS_BillList>();
                PMSBL = Session["billdata"] as List<PMS_BillList>;
                model.MedDetails = clsadmin.ViewMedicines();
                model.BillLists = PMSBL;
                return View(model);
            }
            else
            {
                model.MedDetail = clsadmin.FetchMedicine(Convert.ToString(id));
                model.MedCode = model.MedDetail.MedCode;
                model.MedName = model.MedDetail.MedName;
                model.MedPrice = model.MedDetail.MedPrice;
                model.MedStock = model.MedDetail.MedStock;
                model.MedDetails = clsadmin.ViewMedicines();
                IList<PMS_BillList> PMSBL = new List<PMS_BillList>();
                PMSBL = Session["billdata"] as List<PMS_BillList>;
                model.BillLists = PMSBL;
                
                return View(model);
            }
        }
        public ActionResult AddToBill([Bind( Include = "MedCode,MedStock,MedPrice,MedName,MedQty,BillDate")] PMSModel modelPMS)
        {

            int FinalQty = modelPMS.MedStock - modelPMS.MedQty;

            if (FinalQty >= 0)
            {
                clsseller.UpdateStock(modelPMS.MedCode, FinalQty);
                PMS_BillList bill = new PMS_BillList();
                bill.ID = Convert.ToInt32(modelPMS.MedCode);
                bill.Name = modelPMS.MedName;
                bill.Qty = modelPMS.MedQty;
                bill.Price = modelPMS.MedPrice;
                bill.Total = bill.Qty * bill.Price;
                Session["billamount"] = Convert.ToInt32(Session["billamount"])+ bill.Total;
                IList<PMS_BillList> PMSBL = new List<PMS_BillList>();
                PMSBL = Session["billdata"] as IList<PMS_BillList>;
                PMSBL.Add(bill);
                Session["billdata"] = PMSBL;
                Session["billdate"] = Convert.ToDateTime(modelPMS.BillDate);
            }
            else
            {
                TempData["Error" ]= "Invalid Quantity";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Print()
        {
            Billing_details pmsBill =new Billing_details();
            pmsBill.BillDate = Convert.ToDateTime(Session["billdate"]);
            pmsBill.Seller = Convert.ToInt32(Session["seller"]);
            pmsBill.Amount = Convert.ToInt32(Session["billamount"]);
            
            clsseller.SaveBill(pmsBill);
            return RedirectToAction("Index","Home");
        }






        
    }
    }
