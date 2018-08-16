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
    public class QuestionersController : Controller
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        // GET: Questioners
        public ActionResult Index()
        {
            var questioners = db.Questioners.Include(q => q.Metadata);
            return View(questioners.ToList());
        }

        // GET: Questioners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questioner questioner = db.Questioners.Find(id);
            if (questioner == null)
            {
                return HttpNotFound();
            }
            return View(questioner);
        }

        // GET: Questioners/Create
        public ActionResult Create()
        {
            ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name");
            return View();
        }

        // POST: Questioners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Questioner_Id,Metadata_Id,Questioner1,IsActive")] Questioner questioner)
        {
            if (ModelState.IsValid)
            {
                db.Questioners.Add(questioner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name", questioner.Metadata_Id);
            return View(questioner);
        }

        // GET: Questioners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questioner questioner = db.Questioners.Find(id);
            if (questioner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name", questioner.Metadata_Id);
            return View(questioner);
        }

        // POST: Questioners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Questioner_Id,Metadata_Id,Questioner1,IsActive")] Questioner questioner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questioner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name", questioner.Metadata_Id);
            return View(questioner);
        }

        // GET: Questioners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questioner questioner = db.Questioners.Find(id);
            if (questioner == null)
            {
                return HttpNotFound();
            }
            return View(questioner);
        }

        // POST: Questioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questioner questioner = db.Questioners.Find(id);
            db.Questioners.Remove(questioner);
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
