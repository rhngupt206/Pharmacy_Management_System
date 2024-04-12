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
    public class MedicinesController : Controller
    {
        

        // GET: Medicines
        public ActionResult Index(int? id)
        {
            PMSModel model = new PMSModel();
            if (id == null)
            {
                model.MedDetails = clsadmin.ViewMedicines();
                ViewBag.MedCategory = new SelectList(clsadmin.ViewCategory(), "CatId", "CatName");
                return View(model);
            }
            else
            {
                model.MedDetail = clsadmin.FetchMedicine(Convert.ToString(id));
                model.MedCode = model.MedDetail.MedCode;
                model.MedName = model.MedDetail.MedName;
                model.MedPrice = model.MedDetail.MedPrice;
                model.MedStock= model.MedDetail.MedStock;
                model.MedExpDate= model.MedDetail.MedExpDate;
                model.MedCategory= model.MedDetail.MedCategory;
                model.MedDetails = clsadmin.ViewMedicines();
                ViewBag.MedCategory = new SelectList(clsadmin.ViewCategory(), "CatId", "CatName", model.MedCategory);
                return View(model);
            }            
        }

        [HttpPost]
        public ActionResult Save([Bind(Include = "MedCode,MedName,MedPrice,MedStock,MedExpDate,MedCategory")] Med_details pMSModel)
        {
            if (ModelState.IsValid)
            {
                
                clsadmin.AddMedicine(pMSModel);
                return RedirectToAction("Index");
                //return View(clsadmin.ViewMedicines());
            }
            ViewBag.MedCategory = new SelectList(clsadmin.ViewCategory(), "CatId", "CatName",pMSModel.MedCategory);
            //return View(pMSModel);
            return RedirectToAction("Index", pMSModel);
        }

        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "MedCode,MedName,MedPrice,MedStock,MedExpDate,MedCategory")] PMSModel pMSModel)
        {
            if (ModelState.IsValid)
            {
                clsadmin.UpdateMedicine(pMSModel.MedCode, pMSModel.MedName, pMSModel.MedPrice,pMSModel.MedStock,pMSModel.MedExpDate,pMSModel.MedCategory);
                return RedirectToAction("Index");
            }
            ViewBag.MedCategory = new SelectList(clsadmin.ViewCategory(), "CatId", "CatName", pMSModel.MedCategory);
            //return View(pMSModel);
            return RedirectToAction("Index", pMSModel);
        }


        [HttpPost]
        public ActionResult Delete([Bind(Include = "MedCode,MedName,MedPrice,MedStock,MedExpDate,MedCategory")] PMSModel pMSModel)
        {
            if (ModelState.IsValid)
            {
                clsadmin.DeleteMedicine(pMSModel.MedCode);
                return RedirectToAction("Index");
            }
            ViewBag.MedCategory = new SelectList(clsadmin.ViewCategory(), "CatId", "CatName", pMSModel.MedCategory);
            //return View(pMSModel);
            return RedirectToAction("Index", pMSModel);
        }
    }
}
