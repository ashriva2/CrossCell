using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrossSell_App.DataAccess;

namespace CrossSell_App.Controllers
{
    public class PortfolioAgileLabController : Controller
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();


        static int CompanyId = 0;


        // GET: Portfolio_Agile_Lab
        public ActionResult Index(int companyId)
        {
            ViewBag.fillCompanyddl = FillCompanyDropDown(companyId);
            var portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Include(p => p.Company).Include(p => p.Portfolio);
            return View(portfolio_Agile_Lab.ToList());
        }

        // GET: Portfolio_Agile_Lab/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Agile_Lab portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Find(id);
            if (portfolio_Agile_Lab == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Agile_Lab);
        }

        // GET: Portfolio_Agile_Lab/Create
        public ActionResult Create()
        {
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name");
            ViewBag.Portfolio_Id = new SelectList(db.Portfolios, "Portfolio_Id", "Portfolio_Name");
            return View();
        }

        // POST: Portfolio_Agile_Lab/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pal_Id,Company_Id,Portfolio_Id,Current_Usage,Future_Scope,IsMarketLead")] Portfolio_Agile_Lab portfolio_Agile_Lab)
        {

            if (ModelState.IsValid)
            {
                Repository rep = new Repository();
                if (!rep.CheckIfPortfolio_CompanyExist(portfolio_Agile_Lab.Portfolio_Id, portfolio_Agile_Lab.Company_Id))
                {
                    db.Portfolio_Agile_Lab.Add(portfolio_Agile_Lab);
                    db.SaveChanges();
                }
                else
                {
                    //db.Entry(portfolio_Agile_Lab).State = EntityState.Modified;
                    Portfolio_Agile_Lab UpdateData = new Portfolio_Agile_Lab();
                    UpdateData = db.Portfolio_Agile_Lab.Where(x => x.Portfolio_Id == portfolio_Agile_Lab.Portfolio_Id && x.Company_Id == portfolio_Agile_Lab.Company_Id).FirstOrDefault();
                    UpdateData.Current_Usage = portfolio_Agile_Lab.Current_Usage;
                    UpdateData.IsMarketLead = portfolio_Agile_Lab.IsMarketLead;
                    UpdateData.Future_Scope = portfolio_Agile_Lab.Future_Scope;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name", portfolio_Agile_Lab.Company_Id);
            ViewBag.Portfolio_Id = new SelectList(db.Portfolios, "Portfolio_Id", "Portfolio_Name", portfolio_Agile_Lab.Portfolio_Id);
            return View(portfolio_Agile_Lab);
        }


        //public bool CheckIfPortfolio_CompanyExist(int Portfolio_Id, int Company_Id)
        //{
        //    var Data = db.Portfolio_Agile_Lab.Where(x => x.Portfolio_Id == Portfolio_Id && x.Company_Id == Company_Id).Select(x => x.Pal_Id);
        //    if (Data != null)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}


        // GET: Portfolio_Agile_Lab/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Portfolio_Agile_Lab> portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Where(x => x.Company_Id == id).ToList();
            if (portfolio_Agile_Lab == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company_Name = portfolio_Agile_Lab[0].Company.Company_Name;
            CompanyId = portfolio_Agile_Lab[0].Company.Company_Id;
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name", portfolio_Agile_Lab[0].Company_Id);
            //ViewBag.Portfolio_Id = new SelectList(db.Portfolios, "Portfolio_Id", "Portfolio_Name", portfolio_Agile_Lab[0].Portfolio_Id);
            return View(portfolio_Agile_Lab.ToList());
        }

        // POST: Portfolio_Agile_Lab/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {

            string NextGen_AMSCurrent_Usage = Convert.ToString(Request.Form["NextGen AMSCurrent_Usage"]);

            bool NextGen_AMSFuture_Scope = Convert.ToBoolean(Request.Form["NextGen AMSFuture_Scope"].Split(',')[0]);

            bool NextGen_AMSIsMarketLead = Convert.ToBoolean(Request.Form["NextGen AMSIsMarketLead"].Split(',')[0]);
            Update_Portfolio_Agile_LabData(1, NextGen_AMSCurrent_Usage, NextGen_AMSFuture_Scope, NextGen_AMSIsMarketLead);



            string NextGen_SAPCurrent_Usage = Convert.ToString(Request.Form["NextGen SAPCurrent_Usage"]);
            bool NextGen_SAPFuture_Scope = Convert.ToBoolean(Request.Form["NextGen SAPFuture_Scope"].Split(',')[0]);
            bool NextGen_SAPIsMarketLead = Convert.ToBoolean(Request.Form["NextGen SAPIsMarketLead"].Split(',')[0]);

            Update_Portfolio_Agile_LabData(2, NextGen_SAPCurrent_Usage, NextGen_SAPFuture_Scope, NextGen_SAPIsMarketLead);


            string DCXCurrent_Usage = Convert.ToString(Request.Form["DCXCurrent_Usage"]);
            bool DCXFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["DCXFuture_Scope"]).Split(',')[0]);
            bool DCXIsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["DCXIsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(3, DCXCurrent_Usage, DCXFuture_Scope, DCXIsMarketLead);

            string CloudCurrent_Usage = Convert.ToString(Request.Form["CloudCurrent_Usage"]);
            bool CloudFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["CloudFuture_Scope"]).Split(',')[0]);
            bool CloudIsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["CloudIsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(4, CloudCurrent_Usage, CloudFuture_Scope, CloudIsMarketLead);

            string CyberSecurityCurrent_Usage = Convert.ToString(Request.Form["CyberSecurityCurrent_Usage"]);
            bool CyberSecurityFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["CyberSecurityFuture_Scope"]).Split(',')[0]);
            bool CyberSecurityIsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["CyberSecurityIsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(5, CyberSecurityCurrent_Usage, CyberSecurityFuture_Scope, CyberSecurityIsMarketLead);

            string DigitalMfgCurrent_Usage = Convert.ToString(Request.Form["Digital MfgCurrent_Usage"]);
            bool DigitalMfgFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["Digital MfgFuture_Scope"]).Split(',')[0]);
            bool DigitalMfgIsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["Digital MfgIsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(6, DigitalMfgCurrent_Usage, DigitalMfgFuture_Scope, DigitalMfgIsMarketLead);

            string AICurrent_Usage = Convert.ToString(Request.Form["AICurrent_Usage"]);
            bool AIFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["AIFuture_Scope"]).Split(',')[0]);
            bool AIIsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["AIIsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(7, AICurrent_Usage, AIFuture_Scope, AIIsMarketLead);

            string ChatbotsCurrent_Usage = Convert.ToString(Request.Form["ChatbotsCurrent_Usage"]);
            bool ChatbotsFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["ChatbotsFuture_Scope"]).Split(',')[0]);
            bool ChatbotsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["ChatbotsIsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(8, ChatbotsCurrent_Usage, ChatbotsFuture_Scope, ChatbotsMarketLead);

            string DevOpsCurrent_Usage = Convert.ToString(Request.Form["DevOpsCurrent_Usage"]);
            bool DevOpsFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["DevOpsFuture_Scope"]).Split(',')[0]);
            bool DevOpsIsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["DevOpsIsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(9, DevOpsCurrent_Usage, DevOpsFuture_Scope, DevOpsIsMarketLead);

            string BlockchainCurrent_Usage = Convert.ToString(Request.Form["BlockchainCurrent_Usage"]);
            bool BlockchainFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["BlockchainFuture_Scope"]).Split(',')[0]);
            bool BlockchainIsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["BlockchainIsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(10, BlockchainCurrent_Usage, BlockchainFuture_Scope, BlockchainIsMarketLead);

            string End2EndOfferingCurrent_Usage = Convert.ToString(Request.Form["End To End Offering Current_Usage"]);
            bool End2EndOfferingFuture_Scope = Convert.ToBoolean(Convert.ToString(Request.Form["End To End Offering Future_Scope"]).Split(',')[0]);
            bool End2EndOfferingIsMarketLead = Convert.ToBoolean(Convert.ToString(Request.Form["End To End Offering IsMarketLead"]).Split(',')[0]);

            Update_Portfolio_Agile_LabData(11, End2EndOfferingCurrent_Usage, End2EndOfferingFuture_Scope, End2EndOfferingIsMarketLead);

            //save data




            //if (ModelState.IsValid)
            //{
            //    db.Entry(portfolio_Agile_Lab).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name", portfolio_Agile_Lab.Company_Id);
            //ViewBag.Portfolio_Id = new SelectList(db.Portfolios, "Portfolio_Id", "Portfolio_Name", portfolio_Agile_Lab.Portfolio_Id);
            return RedirectToAction("Index");
        }


        //Save the models data

        public void Update_Portfolio_Agile_LabData(int PortfolioId, string Curr_Usg, bool FutrFcsd, bool IsMrktLd)
        {
            Portfolio_Agile_Lab portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Where(x => x.Company_Id == CompanyId && x.Portfolio_Id == PortfolioId).FirstOrDefault();

            portfolio_Agile_Lab.Current_Usage = Convert.ToInt16(Curr_Usg);
            portfolio_Agile_Lab.Future_Scope = FutrFcsd;
            portfolio_Agile_Lab.IsMarketLead = IsMrktLd;


            db.SaveChanges();
        }

        // GET: Portfolio_Agile_Lab/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Agile_Lab portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Find(id);
            if (portfolio_Agile_Lab == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Agile_Lab);
        }

        // POST: Portfolio_Agile_Lab/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_Agile_Lab portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Find(id);
            db.Portfolio_Agile_Lab.Remove(portfolio_Agile_Lab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private List<SelectListItem> FillCompanyDropDown(int companyId)
        {

            List<SelectListItem> listItems = new List<SelectListItem>();
            var companyList = db.Companies.ToList();

            foreach (var item in companyList)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Company_Name,
                    Value = Convert.ToString(item.Company_Id),
                    Selected = companyId == item.Company_Id ? true : false
                });
            }

            return listItems;
        }
    }
}
