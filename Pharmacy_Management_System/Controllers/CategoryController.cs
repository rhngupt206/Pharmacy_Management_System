using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmacy_Management_System.Models;
using Pharma_Library;

namespace Pharmacy_Management_System.Controllers
{
    public class CategoryController : Controller
    {
        

        // GET: Category
        public ActionResult Index(int? id)
        {
            PMSCat model = new PMSCat();
            if (id == null)
            {
                model.CatDetails= clsadmin.ViewCategory();
                return View(model);
            }
            else
            {
                model.CatDetail = clsadmin.FetchCategory(id);
                model.CatId = model.CatDetail.CatId;
                model.CatName = model.CatDetail.CatName;
                
                model.CatDetails= clsadmin.ViewCategory();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Save([Bind(Include = "CatId,CatName")] Category_details pMSCat)
        {
            if (ModelState.IsValid)
            {
                clsadmin.AddCategory(pMSCat);
                return RedirectToAction("Index");
            }

            //return View(pMSCat);
            return RedirectToAction("Index", pMSCat);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "CatId,CatName")] PMSCat pMSCat)
        {
            if (ModelState.IsValid)
            {
                clsadmin.UpdateCategory(pMSCat.CatId, pMSCat.CatName);
                return RedirectToAction("Index");
            }
            //return View(pMSCat);
            return RedirectToAction("Index", pMSCat);
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "CatId,CatName")] PMSCat pMSCat)
        {
            if (ModelState.IsValid)
            {
                clsadmin.DeleteCategory(pMSCat.CatId);
                return RedirectToAction("Index");
            }
            //return View(pMSCat);
            return RedirectToAction("Index", pMSCat);
        }

        
    }
}
