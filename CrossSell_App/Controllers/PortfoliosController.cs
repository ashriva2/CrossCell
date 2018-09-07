using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrossSell_App.Manager;
using CrossSell_App.Models;
//using CrossSell_App.DataAccess;
using DataAccessLayer;
using DataAccessLayer.Repositories;


namespace CrossSell_App.Controllers
{
    public class PortfoliosController : Controller
    {
       // private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        private PortfolioManager pfRepo = new PortfolioManager();

        // GET: Portfolios
        public ActionResult Index()
        {
            var portfolios = pfRepo.GetPortfolios();
            return View(portfolios.ToList());
        }

        // GET: Portfolios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioTO portfolio = pfRepo.GetPortfoliobyId(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // GET: Portfolios/Create
        public ActionResult Create()
        {
            ViewBag.Portfolio_Type_Id = new SelectList(pfRepo.GetPortfolioTypes(), "Portfolio_Type_Id", "Portfolio_Type_Name");
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Portfolio_Id,Portfolio_Name,Portfolio_Type_Id")] PortfolioTO portfolio)
        {
            if (ModelState.IsValid)
            {
                pfRepo.savePortfolios(portfolio);
                return RedirectToAction("Index");
            }

            ViewBag.Portfolio_Type_Id = new SelectList(pfRepo.GetPortfolioTypes(), "Portfolio_Type_Id", "Portfolio_Type_Name", portfolio.Portfolio_Type_Id);
            return View(portfolio);
        }

        // GET: Portfolios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioTO portfolio = pfRepo.GetPortfoliobyId(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Portfolio_Type_Id = new SelectList(pfRepo.GetPortfolioTypes(), "Portfolio_Type_Id", "Portfolio_Type_Name", portfolio.Portfolio_Type_Id);
            return View(portfolio);
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Portfolio_Id,Portfolio_Name,Portfolio_Type_Id")] PortfolioTO portfolio)
        {
            if (ModelState.IsValid)
            {
                pfRepo.updatePortfolio(portfolio);
                
                return RedirectToAction("Index");
            }
            ViewBag.Portfolio_Type_Id = new SelectList(pfRepo.GetPortfolioTypes(), "Portfolio_Type_Id", "Portfolio_Type_Name", portfolio.Portfolio_Type_Id);
            return View(portfolio);
        }

        // GET: Portfolios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioTO portfolio = pfRepo.GetPortfoliobyId(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Portfolio portfolio = db.Portfolios.Find(id);
            //db.Portfolios.Remove(portfolio);
            //db.SaveChanges();
            pfRepo.deletePortfolio(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
