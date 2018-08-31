using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrossSell_App.Repository;
//using CrossSell_App.DataAccess;
using DataAccessLayer;

namespace CrossSell_App.Controllers
{
    public class MetadatasController : Controller
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        private MetadataRepository metaRepo = new MetadataRepository();

        // GET: Metadatas
        public ActionResult Index()
        {
            return View(metaRepo.GetAllMetadata());
        }

        // GET: Metadatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metadata metadata = metaRepo.GetMetadatabyId(id);
            if (metadata == null)
            {
                return HttpNotFound();
            }
            return View(metadata);
        }

        // GET: Metadatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Metadatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Metadata_Id,Metadata_Name,IsActive")] Metadata metadata)
        {
            if (ModelState.IsValid)
            {
                metaRepo.SaveMetadata(metadata);
                return RedirectToAction("Index");
            }

            return View(metadata);
        }

        // GET: Metadatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metadata metadata = metaRepo.GetMetadatabyId(id);
            if (metadata == null)
            {
                return HttpNotFound();
            }
            return View(metadata);
        }

        // POST: Metadatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Metadata_Id,Metadata_Name,IsActive")] Metadata metadata)
        {
            if (ModelState.IsValid)
            {
                metaRepo.UpdateMetadata(metadata);
                return RedirectToAction("Index");
            }
            return View(metadata);
        }

        // GET: Metadatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metadata metadata = metaRepo.GetMetadatabyId(id);
            if (metadata == null)
            {
                return HttpNotFound();
            }
            return View(metadata);
        }

        // POST: Metadatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            metaRepo.DeleteMetadata(id);
            return RedirectToAction("Index");
        }

       
    }
}
