using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrossSell_App.Models;
using DataAccessLayer;
using DataAccessLayer.Repositories;

using Services;

namespace CrossSell_App.Manager
{
    public class CompaniesManager
    {
        private CompaniesService repo = new CompaniesService();
        public List<CompanyTO> getAllCompanies()
        {

            //return db.Companies.ToList().OrderBy(x => x.Company_Id).ToList();

            var data = repo.getAllCompanies();



            var dataToReturn = data.Select(p => new CompanyTO()
            {
                Company_Name = p.Company_Name,
                CompanyColor = p.CompanyColor,
                Company_Admin = p.Company_Admin,
                Company_Contacts = p.Company_Contacts,
                Company_Id = p.Company_Id,
                IsActive = p.IsActive,
                //Objectives = p.Objectives.Select(x=> new ObjectiveTO { Company_Id=x.Company_Id, }).ToList(),


            }).ToList();

            return dataToReturn;


        }

        public CompanyTO getAllCompanybyId(int? id)
        {

            // return repo.getAllCompanybyId(id);
            return repo.getAllCompanies().Where(x => x.Company_Id == id).Select(p => new CompanyTO()
            {
                Company_Name = p.Company_Name,
                CompanyColor = p.CompanyColor,
                Company_Admin = p.Company_Admin,
                Company_Contacts = p.Company_Contacts,
                Company_Id = p.Company_Id,
                IsActive = p.IsActive

            }).FirstOrDefault();
        }

        public void saveCompany(CompanyTO company)
        {
            Company dataTOsave = new Company()
            {
                Company_Name = company.Company_Name,
                CompanyColor = company.CompanyColor,
                Company_Admin = company.Company_Admin,
                Company_Contacts = company.Company_Contacts,
                IsActive = true


            };
            repo.saveCompany(dataTOsave);




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




        public void updateUserrole(UserRoleTO user)
        {
            UserRole dataToUpdate = new UserRole()
            {
                EmailId = user.EmailId,
                IsAdmin = user.IsAdmin
            };
            repo.updateUserrole(dataToUpdate);

        }


        public void updateUserAccess(UserAccessTO user)
        {
            UserAccess dataToUpdate = new UserAccess()
            {
                CompanyId = user.CompanyId,
                UserRoleId = user.UserRoleId


            };
            repo.updateUserAccess(dataToUpdate);
        }

        public List<UserRoleTO> getAllUserrole()
        {
            var data = repo.getAllUserrole();

            var result = data.Select(x => new UserRoleTO()
            {

                UserRoleId = x.UserRoleId,
                EmailId = x.EmailId,
                IsAdmin = x.IsAdmin

            }).ToList();
            return result;
        }

        public List<UserAccessTO> getAllUserAccess()
        {


            var data = repo.getAllUserAccess();

            var result = data.Select(x => new UserAccessTO()
            {

                CompanyId = x.CompanyId,
                UserRoleId = x.UserRoleId,
                UserAccessId = x.UserAccessId

            }).ToList();
            return result;
        }


        public void updateCompany(CompanyTO company)
        {
            Company dataToUpdate = new Company();
            dataToUpdate.Company_Id = company.Company_Id;
            dataToUpdate.Company_Name = company.Company_Name;
            dataToUpdate.CompanyColor = company.CompanyColor;
            dataToUpdate.Company_Contacts = company.Company_Contacts;
            dataToUpdate.Company_Admin = company.Company_Admin;
            dataToUpdate.IsActive = company.IsActive;
            repo.updateCompany(dataToUpdate);

        }

        public void deleteCompany(int id)
        {
            repo.deleteCompany(id);
        }
    }
}
