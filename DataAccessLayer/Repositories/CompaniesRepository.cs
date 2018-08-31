using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CompaniesRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        public List<Company> getAllCompanies()
        {
                   
            return db.Companies.ToList().OrderBy(x => x.Company_Id).ToList();
        }

        public Company getAllCompanybyId(int? id)
        {

            return db.Companies.Where(x => x.Company_Id == id).FirstOrDefault();
        }

        public void saveCompany(Company company)
        {
            db.Companies.Add(company);
            int companyId = db.Companies.Where(x=>x.Company_Name == company.Company_Name).Select(x =>x.Company_Id).FirstOrDefault();
            if (company.Company_Admin != "")
            {
                UserRole users = new UserRole();
                users.EmailId = company.Company_Admin;
                users.IsAdmin = true;
                saveUserrole(users);

                UserAccess Role = new UserAccess()
                {

                    CompanyId = companyId,
                    UserRoleId =getAllUserrole().Where(x => x.EmailId == company.Company_Contacts).Select(x => x.UserRoleId).FirstOrDefault()


                };
                saveUserAccess(Role);
            }

            if (company.Company_Contacts != "")
            {
                UserRole users = new UserRole();
                users.EmailId = company.Company_Admin;
                users.IsAdmin = false;
                saveUserrole(users);

                UserAccess Role = new UserAccess()
                {

                    CompanyId = companyId,
                    UserRoleId = getAllUserrole().Where(x => x.EmailId == company.Company_Contacts).Select(x => x.UserRoleId).FirstOrDefault()


                };

                saveUserAccess(Role);


            }
          
            db.SaveChanges();
        }


       



        public void saveUserrole(UserRole user)
        {

            db.UserRoles.Add(user);
            db.SaveChanges();
        }


        public void saveUserAccess(UserAccess user)
        {

            db.UserAccesses.Add(user);
            db.SaveChanges();
        }




        public void updateUserrole(UserRole user)
        {
            UserRole dataToupdate = db.UserRoles.Where(x => x.UserRoleId == user.UserRoleId).FirstOrDefault();
            dataToupdate.EmailId = user.EmailId;
            dataToupdate.IsAdmin = user.IsAdmin;
           

           
            db.SaveChanges();
        }


        public void updateUserAccess(UserAccess user)
        {
            UserAccess dataToupdate = db.UserAccesses.Where(x => x.UserRoleId == user.UserRoleId).FirstOrDefault();
        
            dataToupdate.CompanyId = user.CompanyId;
            dataToupdate.UserRoleId = user.UserRoleId;


            db.UserAccesses.Add(user);
            db.SaveChanges();
        }

















        public List<UserRole> getAllUserrole()
        {
            return db.UserRoles.ToList();
        }

        public List<UserAccess> getAllUserAccess()
        {
            return db.UserAccesses.ToList();
        }


        public void updateCompany(Company company)
        {
            Company dataToUpdate = db.Companies.Where(x => x.Company_Id == company.Company_Id).FirstOrDefault();
            dataToUpdate.Company_Name = company.Company_Name;
            dataToUpdate.CompanyColor = company.CompanyColor;
            dataToUpdate.Company_Contacts = company.Company_Contacts;
            dataToUpdate.Company_Admin = company.Company_Admin;
          
            db.SaveChanges();

        }

        public void deleteCompany(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
        }
    }
}
