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
        public ActionResult Create([Bind(Include = "Company_Id,Company_Name,IsActive,Company_Contacts,Company_Admin,CompanyColor")] Company company)
        {
            if (ModelState.IsValid)
            {
                var Color_exist = db.Companies.Where(x => x.CompanyColor == company.CompanyColor).FirstOrDefault();
                if(Color_exist!= null && Color_exist.Company_Id != company.Company_Id)
                {
                    ModelState.AddModelError(string.Empty, "There is something wrong with Foo.");
                    return View(company);
                }
                //logic to enter the users 
                if (company.Company_Admin != "")
                {
                    UserRole users = new UserRole();
                    users.EmailId = company.Company_Admin;
                    users.IsAdmin = true;
                    SaveAdminAndContacts(users);

                    UserAccess Role = new UserAccess()
                    {

                        CompanyId = company.Company_Id,
                        UserRoleId = db.UserRoles.Where(x => x.EmailId == company.Company_Contacts).Select(x => x.UserRoleId).FirstOrDefault()


                    };
                    UpdateUserAccess(Role);
                }

                if (company.Company_Contacts != "")
                {
                    UserRole users = new UserRole();
                    users.EmailId = company.Company_Admin;
                    users.IsAdmin = false;
                    SaveAdminAndContacts(users);

                    UserAccess Role = new UserAccess()
                    {

                        CompanyId = company.Company_Id,
                        UserRoleId = db.UserRoles.Where(x => x.EmailId == company.Company_Contacts).Select(x => x.UserRoleId).FirstOrDefault()


                    };

                    UpdateUserAccess(Role);


                }
               


                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        public void UpdateUserAccess(UserAccess role)
        {
            UserAccess dataUpdate = db.UserAccesses.Where(x => x.UserRoleId == role.UserRoleId).FirstOrDefault();
            dataUpdate.CompanyId = role.CompanyId;
            dataUpdate.UserRoleId = role.UserRoleId;

            db.SaveChanges();
        }
        public void saveContactsToUserRole(UserAccess role)
        {
            db.UserAccesses.Add(role);
            db.SaveChanges();
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

            List<UserAccess> userAccess=db.UserAccesses.Where(x => x.CompanyId == id).ToList();
            List<int> userRoleId = new List<int>();
            foreach(var item in userAccess)
            {
                userRoleId.Add(item.UserRoleId);
            }

            var userRolesIsAdmin=db.UserRoles.Where(c=> userRoleId.Contains(c.UserRoleId)).Select(x=>new { x.EmailId,x.IsAdmin}).ToList();
            //string contactEmailId= 
           

            company.Company_Admin = userRolesIsAdmin.Where(x => x.IsAdmin==true).Select(x=>x.EmailId).FirstOrDefault();
            company.Company_Contacts = userRolesIsAdmin.Where(x => x.IsAdmin == false).Select(x => x.EmailId).FirstOrDefault();

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
        public ActionResult Edit([Bind(Include = "Company_Id,Company_Name,IsActive,Company_Contacts,Company_Admin,CompanyColor")] Company company)
        {
            if (ModelState.IsValid)
            {
                var Color_exist = db.Companies.Where(x => x.CompanyColor == company.CompanyColor).FirstOrDefault();
                if (Color_exist != null && Color_exist.Company_Id!=company.Company_Id)
                {
                    ModelState.AddModelError(string.Empty, "There is something wrong with Foo.");
                    return View(company);
                }

                if (company.Company_Admin != "")
                {
                    UserRole users = new UserRole();
                    users.EmailId = company.Company_Admin;
                    users.IsAdmin = true;
                    SaveAdminAndContacts(users);

                    UserAccess Role = new UserAccess()
                    {

                        CompanyId = company.Company_Id,
                        UserRoleId = db.UserRoles.Where(x => x.EmailId == company.Company_Contacts).Select(x => x.UserRoleId).FirstOrDefault()


                    };
                    saveContactsToUserRole(Role);
                }

                if (company.Company_Contacts != "")
                {
                    UserRole users = new UserRole();
                    users.EmailId = company.Company_Admin;
                    users.IsAdmin = false;
                    SaveAdminAndContacts(users);


                    UserAccess Role = new UserAccess()
                    {

                        CompanyId = company.Company_Id,
                        UserRoleId = db.UserRoles.Where(x => x.EmailId == company.Company_Contacts).Select(x => x.UserRoleId).FirstOrDefault()


                    };
                }
                Company dataToupdate = db.Companies.Where(x => x.Company_Id == company.Company_Id).FirstOrDefault();

                dataToupdate.CompanyColor = company.CompanyColor;
                dataToupdate.Company_Name = company.Company_Name;
                dataToupdate.Company_Admin = company.Company_Admin;
                dataToupdate.Company_Contacts = company.Company_Contacts;
                //db.Entry(company).State = EntityState.Modified;
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
