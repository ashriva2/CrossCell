﻿using CrossSell_App.DataAccess;
using CrossSell_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        public ActionResult Index(UserDetails model, FormCollection form,string returnUrl)
        {
            

            if(ModelState.IsValid)
            {
                string strDDLValue = Request.Form["Role"].ToString();
                string userName = Convert.ToString(Request.Form["UserName"]);
                string password = Convert.ToString(Request.Form["Password"]);
                

                var IsUserexist = db.UserRoles.Where(x => x.EmailId == userName).FirstOrDefault();

                
                FormsAuthentication.SetAuthCookie(userName, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    //if (strDDLValue == "Admin" && (userName == "admin" || userName == "Admin") && password == "admin")
                    //{
                    //    return Redirect("/Home/Index");
                    //}
                    if (IsUserexist != null)
                    {
                        if (IsUserexist.IsAdmin)
                        {
                            return Redirect("/Home/Index");
                        }
                        else
                        {
                             var companyId = db.UserAccesses.Where(x => x.UserRoleId == IsUserexist.UserRoleId).Select(x => x.CompanyId).FirstOrDefault();
                          
                            Session["companyId"] = companyId;
                            return Redirect("/Home/Index");
                        }
                      

                    }

                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        ViewBag.Message = "The user name or password provided is incorrect.";
                    }
                }


                
                
                    //return Redirect("/PortfolioAgileLab/Index");
            }

            //var data = db.CrossSells.Where(x => x.Company_Id == 1).ToList();

            return View(model);
            
        }
    }
}