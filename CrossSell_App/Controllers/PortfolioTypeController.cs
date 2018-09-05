using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using DTO;
//using CrossSell_App.DataAccess;

namespace CrossSell_App.Controllers
{
    public class PortfolioTypeController : Controller
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        private PortfolioTypeRepository ptfTypeRepo = new PortfolioTypeRepository();
        // GET: PortfolioType
        public ActionResult Index()
        {
            return View(ptfTypeRepo.GetPortfolioTypes());
        }

        // GET: PortfolioType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioTypeTO portfolio_Type = ptfTypeRepo.getPortfolioTypebyId(id);
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
        public ActionResult Create([Bind(Include = "Portfolio_Type_Id,Portfolio_Type_Name")] PortfolioTypeTO portfolio_Type)
        {
            if (portfolio_Type.Portfolio_Type_Name!="" && portfolio_Type.Portfolio_Type_Name != null)
            {
                ptfTypeRepo.savePortfolioType(portfolio_Type);
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
            PortfolioTypeTO portfolio_Type = ptfTypeRepo.getPortfolioTypebyId(id);
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
        public ActionResult Edit([Bind(Include = "Portfolio_Type_Id,Portfolio_Type_Name")] PortfolioTypeTO portfolio_Type)
        {
            if (portfolio_Type.Portfolio_Type_Name != "" || portfolio_Type.Portfolio_Type_Name != null)
            {
                ptfTypeRepo.updatePortfolioType(portfolio_Type);
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
            PortfolioTypeTO portfolio_Type = ptfTypeRepo.getPortfolioTypebyId(id);
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
            ptfTypeRepo.deletePortfolioTypes(id);
            return RedirectToAction("Index");
        }

      
    }
}
