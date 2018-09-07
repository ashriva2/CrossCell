
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrossSell_App.Repository;
//using System.Data.Entity;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace Services
{
    public class PortfolioAgileLabService
    {
        private PortfolioAgileLabRepository repo = new PortfolioAgileLabRepository();

        public List<Portfolio_Agile_Lab> GetAllPAL()
        {
            return repo.GetAllPAL();

            //var dataToReturn = data.Select(x => new PortfolioAgileLabTO
            //{

            //    Company_Id = x.Company_Id,
            //    Current_Usage = x.Current_Usage,
            //    Future_Scope = x.Future_Scope,
            //    IsMarketLead = x.IsMarketLead,
            //    Pal_Id = x.Pal_Id,
            //    Portfolio_Id = x.Portfolio_Id

            //});
            //return dataToReturn.ToList();
        }

        public List<Portfolio_Agile_Lab> GetPALByCompanyId(int? id)
        {
            return repo.GetPALByCompanyId(id);

            //var result = data.Select(x=> new PortfolioAgileLabTO(){
            //    Company_Id = x.Company_Id,                   
            //    Current_Usage = x.Current_Usage,
            //    Future_Scope = x.Future_Scope,
            //    IsMarketLead = x.IsMarketLead,
            //    Pal_Id = x.Pal_Id,
            //    Portfolio=new PortfolioTO {
            //        Portfolio_Id = x.Portfolio_Id,
            //        Portfolio_Name = x.Portfolio.Portfolio_Name                                      
            //    },
            //    Portfolio_Id = x.Portfolio_Id }).ToList();






            //return result;
        }



        public Company getAllCompanybyId(int? id)
        {

            return repo.getAllCompanybyId(id);
        }


        public List<Portfolio_Type> GetAllPortfolioType()
        {
            return repo.GetAllPortfolioType();
        }

        public List<Portfolio> GetAllPortfolio()
        {
            return repo.GetAllPortfolio();

            //var dataToReturn = data.Select(x => new PortfolioTO
            //{
            //    Portfolio_Id = x.Portfolio_Id,
            //    Portfolio_Name = x.Portfolio_Name,
            //    Portfolio_Type_Id = x.Portfolio_Type_Id

            //});
            //return dataToReturn.ToList();
        }

        public List<Company> GetAllCompanies()
        {
            //return db.Companies.OrderBy(t=>t.Company_Id).ToList();
            return repo.GetAllCompanies();



            //var dataToReturn = data.Select(p => new CompanyTO()
            //{
            //    Company_Name = p.Company_Name,
            //    CompanyColor = p.CompanyColor,
            //    Company_Admin = p.Company_Admin,
            //    Company_Contacts = p.Company_Contacts,
            //    Company_Id = p.Company_Id,
            //    IsActive = p.IsActive,
            //    //Objectives = p.Objectives.Select(x=> new ObjectiveTO { Company_Id=x.Company_Id, }).ToList(),


            //}).ToList();

            //return dataToReturn;
        }


        public Portfolio_Agile_Lab getPalbyId(int? id)
        {
            return repo.getPalbyId(id);

            //     PortfolioAgileLabTO()
            //{

            //    Company_Id = x.Company_Id,
            //    Current_Usage = x.Current_Usage,
            //    Future_Scope = x.Future_Scope,
            //    IsMarketLead = x.IsMarketLead,
            //    Pal_Id = x.Pal_Id,
            //    Portfolio_Id = x.Portfolio_Id
            //}).FirstOrDefault();
            //return data;
        }

        public void DeletePAL(int? id)
        {
            repo.DeletePAL(id);
        }



        public void Update_Portfolio_Agile_LabData(int PortfolioId, string Curr_Usg, bool FutrFcsd, bool IsMrktLd, int CompanyId)
        {
            repo.Update_Portfolio_Agile_LabData(PortfolioId, Curr_Usg, FutrFcsd, IsMrktLd, CompanyId);
        }


        public void savePALData(Portfolio_Agile_Lab dataTOsave)
        {
            repo.savePALData(dataTOsave);
            //Portfolio_Agile_Lab dataTosave = new Portfolio_Agile_Lab()
            //{
            //    Company_Id = dataTOsave.Company_Id,
            //    Current_Usage = dataTOsave.Current_Usage,
            //    Future_Scope = dataTOsave.Future_Scope,
            //    IsMarketLead = dataTOsave.IsMarketLead,
            //    Pal_Id = dataTOsave.Pal_Id,
            //    Portfolio_Id = dataTOsave.Portfolio_Id
            //};


            //try
            //{
            //    db.Portfolio_Agile_Lab.Add(dataTosave);
            //    db.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //}

        }



        public bool CheckIfPortfolio_CompanyExist(int Portfolio_Id, int Company_Id)
        {
            return repo.CheckIfPortfolio_CompanyExist(Portfolio_Id, Company_Id);

        }
    }

   
}