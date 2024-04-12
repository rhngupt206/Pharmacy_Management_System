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
    public class SellerController : Controller
    {
        private PMSDBContext db = new PMSDBContext();

        public ActionResult Index(int? id)
        {
            PMSSeller model = new PMSSeller();
            if (id == null)
            {
                model.SellerDetails = clsadmin.ViewSeller();
                return View(model);
            }
            else
            {
                model.SellerDetail = clsadmin.FetchSeller(Convert.ToInt32(id));
                model.SelId = model.SellerDetail.SelId;
                model.SelName = model.SellerDetail.SelName;
                model.SelEmail = model.SellerDetail.SelEmail;
                model.SelPwd = model.SellerDetail.SelPwd;
                model.SelDOB = model.SellerDetail.SelDOB;
                model.SelGen = model.SellerDetail.SelGen;
                model.SelAdd = model.SellerDetail.SelAdd;
                model.SellerDetails = clsadmin.ViewSeller();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Save([Bind(Include = "SelId,SelName,SelEmail,SelPwd,SelDOB,SelGen,SelAdd")] Seller_details pMSSeller)
        {
            if (ModelState.IsValid)
            {
                clsadmin.AddSeller(pMSSeller);
                return RedirectToAction("Index");
                
            }
            return RedirectToAction("Index", pMSSeller);
            
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "SelId,SelName,SelEmail,SelPwd,SelDOB,SelGen,SelAdd")] PMSSeller pMSSeller)
        {
            if (ModelState.IsValid)
            {
                clsadmin.UpdateSeller(pMSSeller.SelId, pMSSeller.SelName, pMSSeller.SelEmail, pMSSeller.SelPwd, pMSSeller.SelDOB, pMSSeller.SelGen, pMSSeller.SelAdd);
                return RedirectToAction("Index");
            }
            //return View(pMSSeller);
            return RedirectToAction("Index", pMSSeller);
        }


        [HttpPost]
        public ActionResult Delete([Bind(Include = "SelId,SelName,SelEmail,SelPwd,SelDOB,SelGen,SelAdd")] PMSSeller pMSSeller)
        {
            if (ModelState.IsValid)
            {
                clsadmin.DeleteSeller(pMSSeller.SelId);
                return RedirectToAction("Index");
            }
            //return View(pMSSeller);
            return RedirectToAction("Index", pMSSeller);
        }
        
    }
}
