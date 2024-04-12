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
using System.Web.ModelBinding;

namespace Pharmacy_Management_System.Controllers
{
    public class HomeController : Controller
    {
        

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogInAsAdmin() 
        {
            return View("LogInAsAdmin");
        }
        [HttpPost]
        public ActionResult LogInAsAdmin(string username,string password)
        {
            if(username=="Admin" && password=="admin123@")
            {
                return RedirectToAction("Index","Medicines");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password";
                return View();
            }
        }
        
        public ActionResult LogInAsSeller()
        {
            return View("LogInAsSeller");
        }

        [HttpPost]
        public ActionResult LogInAsSeller([Bind(Include = "SelId,SelEmail,SelPwd")] PMSSeller pMSSeller)
        {
            if (clsadmin.Authenticate(pMSSeller.SelEmail, pMSSeller.SelPwd) > 0)
            {
                Session["seller"] = clsadmin.Authenticate(pMSSeller.SelEmail, pMSSeller.SelPwd);
                return RedirectToAction("Index", "Bill");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password";
                return View("LogInAsSeller");
            }
            
        }
        
        
    }
}
