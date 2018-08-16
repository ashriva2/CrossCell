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
    public class CompaniesController : Controller
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

      
        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Company_Id,Company_Name,IsActive,Company_Contacts,Company_Admin")] Company company)
        {
            if (ModelState.IsValid)
            {

                //logic to enter the users 
                if (company.Company_Admin != "")
                {
                    UserRole users = new UserRole();
                    users.EmailId = company.Company_Admin;
                    users.IsAdmin = true;
                    SaveAdminAndContacts(users);
                }

                if (company.Company_Contacts != "")
                {
                    UserRole users = new UserRole();
                    users.EmailId = company.Company_Admin;
                    users.IsAdmin = false;
                    SaveAdminAndContacts(users);
                }


                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }


        public void SaveAdminAndContacts(UserRole users)
        {
            db.UserRoles.Add(users);
            db.SaveChanges();
        }


        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Company_Id,Company_Name,IsActive,Company_Contacts,Company_Admin")] Company company)
        {
            if (ModelState.IsValid)
            {


                if (company.Company_Admin != "")
                {
                    UserRole users = new UserRole();
                    users.EmailId = company.Company_Admin;
                    users.IsAdmin = true;
                    SaveAdminAndContacts(users);
                }

                if (company.Company_Contacts != "")
                {
                    UserRole users = new UserRole();
                    users.EmailId = company.Company_Admin;
                    users.IsAdmin = false;
                    SaveAdminAndContacts(users);
                }


                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
