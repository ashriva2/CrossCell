using CrossSell_App.Models;
using DataAccessLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Manager
{
    public class PortfolioAgileLabManager
    {
        private PortfolioAgileLabService repo = new PortfolioAgileLabService();

        public List<PortfolioAgileLabTO> GetAllPAL()
        {
            var data= repo.GetAllPAL();

            var dataToReturn = data.Select(x => new PortfolioAgileLabTO
            {

                Company_Id = x.Company_Id,
                Current_Usage = x.Current_Usage,
                Future_Scope = x.Future_Scope,
                IsMarketLead = x.IsMarketLead,
                Pal_Id = x.Pal_Id,
                Portfolio_Id = x.Portfolio_Id

            });
            return dataToReturn.ToList();
        }

        public List<PortfolioAgileLabTO> GetPALByCompanyId(int? id)
        {
            var data= repo.GetPALByCompanyId(id);

            var result = data.Select(x => new PortfolioAgileLabTO()
            {
                Company_Id = x.Company_Id,
                Current_Usage = x.Current_Usage,
                Future_Scope = x.Future_Scope,
                IsMarketLead = x.IsMarketLead,
                Pal_Id = x.Pal_Id,
                Portfolio = new PortfolioTO
                {
                    Portfolio_Id = x.Portfolio_Id,
                    Portfolio_Name = x.Portfolio.Portfolio_Name
                },
                Portfolio_Id = x.Portfolio_Id
            }).ToList();






            return result;
        }



        public CompanyTO getAllCompanybyId(int? id)
        {

            var p= repo.getAllCompanybyId(id);
            CompanyTO result = new CompanyTO()
            {
                Company_Name = p.Company_Name,
                CompanyColor = p.CompanyColor,
                Company_Admin = p.Company_Admin,
                Company_Contacts = p.Company_Contacts,
                Company_Id = p.Company_Id,
                IsActive = p.IsActive
            };
            return result;
        }


        public List<PortfolioTypeTO> GetAllPortfolioType()
        {
            var data= repo.GetAllPortfolioType();

            var result = data.Select(x => new PortfolioTypeTO()
            {

                Portfolio_Type_Id = x.Portfolio_Type_Id,
                Portfolio_Type_Name = x.Portfolio_Type_Name,
                IsActive = x.IsActive
            }).ToList();

            return result;

        }

        public List<PortfolioTO> GetAllPortfolio()
        {
            var data= repo.GetAllPortfolio();

            var dataToReturn = data.Select(x => new PortfolioTO
            {
                Portfolio_Id = x.Portfolio_Id,
                Portfolio_Name = x.Portfolio_Name,
                Portfolio_Type_Id = x.Portfolio_Type_Id

            });
            return dataToReturn.ToList();
        }

        public List<CompanyTO> GetAllCompanies()
        {
            //return db.Companies.OrderBy(t=>t.Company_Id).ToList();
            var data= repo.GetAllCompanies();



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


        public PortfolioAgileLabTO getPalbyId(int? id)
        {
            var x= repo.getPalbyId(id);

           PortfolioAgileLabTO portfolioagilelabto=new PortfolioAgileLabTO()
            {

                Company_Id=x.Company_Id,
                 Current_Usage=x.Current_Usage,
                  Future_Scope=x.Future_Scope,
                   IsMarketLead=x.IsMarketLead,
                    Pal_Id=x.Pal_Id,
                     Portfolio_Id=x.Portfolio_Id

            };
            return portfolioagilelabto;
        }

        public void DeletePAL(int? id)
        {
            repo.DeletePAL(id);
        }



        public void Update_Portfolio_Agile_LabData(int PortfolioId, string Curr_Usg, bool FutrFcsd, bool IsMrktLd, int CompanyId)
        {
            repo.Update_Portfolio_Agile_LabData(PortfolioId, Curr_Usg, FutrFcsd, IsMrktLd, CompanyId);
        }


        public void savePALData(PortfolioAgileLabTO dataTOsave)
        {
            Portfolio_Agile_Lab data = new Portfolio_Agile_Lab()
            {
                Company_Id = dataTOsave.Company_Id,
                Current_Usage = dataTOsave.Current_Usage,
                Future_Scope = dataTOsave.Future_Scope,
                IsMarketLead = dataTOsave.IsMarketLead,
                Pal_Id = dataTOsave.Pal_Id,
                Portfolio_Id = dataTOsave.Portfolio_Id
            };
            repo.savePALData(data);
            


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
