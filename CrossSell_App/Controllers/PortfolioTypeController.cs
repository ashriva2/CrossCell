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
    public class PortfolioTypeController : Controller
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        // GET: PortfolioType
        public ActionResult Index()
        {
            return View(db.Portfolio_Type.ToList());
        }

        // GET: PortfolioType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Type portfolio_Type = db.Portfolio_Type.Find(id);
            if (portfolio_Type == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Type);
        }

        // GET: PortfolioType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Portfolio_Type_Id,Portfolio_Type_Name")] Portfolio_Type portfolio_Type)
        {
            if (ModelState.IsValid)
            {
                db.Portfolio_Type.Add(portfolio_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio_Type);
        }

        // GET: PortfolioType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Type portfolio_Type = db.Portfolio_Type.Find(id);
            if (portfolio_Type == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Type);
        }

        // POST: PortfolioType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Portfolio_Type_Id,Portfolio_Type_Name")] Portfolio_Type portfolio_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio_Type);
        }

        // GET: PortfolioType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Type portfolio_Type = db.Portfolio_Type.Find(id);
            if (portfolio_Type == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Type);
        }

        // POST: PortfolioType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_Type portfolio_Type = db.Portfolio_Type.Find(id);
            db.Portfolio_Type.Remove(portfolio_Type);
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
    }
}
