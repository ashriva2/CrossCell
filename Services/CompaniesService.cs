using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repositories;


namespace Services
{
    public class CompaniesService
    {
    private CompaniesRepository repo = new CompaniesRepository();
        public List<Company> getAllCompanies()
        {

            //return db.Companies.ToList().OrderBy(x => x.Company_Id).ToList();

            var data= repo.getAllCompanies();



        //    var dataToReturn = data.Select(p => new Company()
        //    {
        //        Company_Name = p.Company_Name,
        //        CompanyColor = p.CompanyColor,
        //        Company_Admin = p.Company_Admin,
        //        Company_Contacts = p.Company_Contacts,
        //        Company_Id = p.Company_Id,
        //        IsActive = p.IsActive,
        //        //Objectives = p.Objectives.Select(x=> new ObjectiveTO { Company_Id=x.Company_Id, }).ToList(),
               
                  
        //}).ToList();

            return data;


        }

        public Company getAllCompanybyId(int? id)
        {

            return repo.getAllCompanybyId(id);
        }

        public void saveCompany(Company company)
        {
            Company dataTOsave = new Company()
            {
                Company_Name = company.Company_Name,
                CompanyColor = company.CompanyColor,
                Company_Admin = company.Company_Admin,
                Company_Contacts = company.Company_Contacts,
                 IsActive=true
                 

            };
            repo.saveCompany(dataTOsave);

            //db.Companies.Add(dataTOsave);
            //db.SaveChanges();
            int companyId = repo.getAllCompanies().Where(x=>x.Company_Name == company.Company_Name).Select(x =>x.Company_Id).FirstOrDefault();
            if (company.Company_Admin != "")
            {
                UserRole users = new UserRole();
                users.EmailId = company.Company_Admin;
                users.IsAdmin = true;
                repo.saveUserrole(users);

                UserAccess Role = new UserAccess()
                {

                    CompanyId = companyId,
                    UserRoleId =getAllUserrole().Where(x => x.EmailId == company.Company_Contacts).Select(x => x.UserRoleId).FirstOrDefault()


                };
                repo.saveUserAccess(Role);
            }

            if (company.Company_Contacts != "")
            {
                UserRole users = new UserRole();
                users.EmailId = company.Company_Admin;
                users.IsAdmin = false;
                repo.saveUserrole(users);

                UserAccess Role = new UserAccess()
                {

                    CompanyId = companyId,
                    UserRoleId = getAllUserrole().Where(x => x.EmailId == company.Company_Contacts).Select(x => x.UserRoleId).FirstOrDefault()


                };

                repo.saveUserAccess(Role);


            }
          
            //db.SaveChanges();
        }


       



        //public void saveUserrole(UserRole user)
        //{

        //    db.UserRoles.Add(user);
        //    db.SaveChanges();
        //}


        //public void saveUserAccess(UserAccess user)
        //{

        //    db.UserAccesses.Add(user);
        //    db.SaveChanges();
        //}




        public void updateUserrole(UserRole user)
        {
            repo.updateUserrole(user);          
           
        }


        public void updateUserAccess(UserAccess user)
        {
            repo.updateUserAccess(user);
        }

















        public List<UserRole> getAllUserrole()
        {
            return repo.getAllUserrole();
        }

        public List<UserAccess> getAllUserAccess()
        {
            return repo.getAllUserAccess();
        }


        public void updateCompany(Company company)
        {

            repo.updateCompany(company);

        }

        public void deleteCompany(int id)
        {
            repo.deleteCompany(id);
        }
    }
}
