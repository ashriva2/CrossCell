using CrossSell_App.DataAccess;
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
               

                    FormsAuthentication.SetAuthCookie(userName, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    if (strDDLValue == "Admin" && (userName == "admin"|| userName == "Admin"))
                        return Redirect("/Home/Index");

                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }


                
                
                    //return Redirect("/PortfolioAgileLab/Index");
            }

            //var data = db.CrossSells.Where(x => x.Company_Id == 1).ToList();

            return View(model);
            
        }
    }
}