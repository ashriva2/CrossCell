﻿using CrossSell_App.DataAccess;
using CrossSell_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrossSell_App.Controllers
{
    public class LoginController : Controller
    {

        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserDetails model, FormCollection form )
        {
            //ConsumerBankingEntities cbe = new ConsumerBankingEntities();
            //var s = cbe.GetCBLoginInfo(model.UserName, model.Password);

            //var item = s.FirstOrDefault();
            //if (item == "Success")
            //{

            //    return View("UserLandingView");
            //}
            //else if (item == "User Does not Exists")

            //{
            //    ViewBag.NotValidUser = item;

            //}
            //else
            //{
            //    ViewBag.Failedcount = item;
            //}

            //return View("Index");
            string strDDLValue = Request.Form["Role"].ToString();
            //var data = db.CrossSells.Where(x => x.Company_Id == 1).ToList();


            if(strDDLValue=="Admin")
               return Redirect("/Home/Index");
            else
                return Redirect("/PortfolioAgileLab/Index");
        }
    }
}