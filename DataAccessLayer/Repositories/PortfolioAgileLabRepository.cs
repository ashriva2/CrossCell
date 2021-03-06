﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DataAccessLayer;
using DTO;

namespace CrossSell_App.Repository
{
    public class PortfolioAgileLabRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        public List<PortfolioAgileLabTO> GetAllPAL()
        {
            var data = db.Portfolio_Agile_Lab.Include(p => p.Company).Include(p => p.Portfolio);

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
            var data = db.Portfolio_Agile_Lab.Where(x => x.Company_Id == id).Include(p => p.Company).Include(p => p.Portfolio).ToList();

            var result = data.Select(x=> new PortfolioAgileLabTO(){
                Company_Id = x.Company_Id,                   
                Current_Usage = x.Current_Usage,
                Future_Scope = x.Future_Scope,
                IsMarketLead = x.IsMarketLead,
                Pal_Id = x.Pal_Id,
                Portfolio=new PortfolioTO {
                    Portfolio_Id = x.Portfolio_Id,
                    Portfolio_Name = x.Portfolio.Portfolio_Name                                      
                },
                Portfolio_Id = x.Portfolio_Id }).ToList();

           

               

           
            return result;
        }



        public CompanyTO getAllCompanybyId(int? id)
        {

            return db.Companies.Where(x => x.Company_Id == id).Select(p => new CompanyTO()
            {
                Company_Name = p.Company_Name,
                CompanyColor = p.CompanyColor,
                Company_Admin = p.Company_Admin,
                Company_Contacts = p.Company_Contacts,
                Company_Id = p.Company_Id,
                IsActive = p.IsActive

            }).FirstOrDefault();
        }


        public List<PortfolioTypeTO> GetAllPortfolioType()
        {
            return db.Portfolio_Type.ToList().OrderBy(x => x.Portfolio_Type_Id).Select(
                 x => new PortfolioTypeTO()
                 {
                     Portfolio_Type_Id = x.Portfolio_Type_Id,
                     Portfolio_Type_Name = x.Portfolio_Type_Name
                 }

                 ).ToList();
        }

        public List<PortfolioTO> GetAllPortfolio()
        {
            var data = db.Portfolios.Where(x => x.IsActive == true).ToList();

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
            var data = db.Companies.Where(x=>x.IsActive == true).ToList().OrderBy(x => x.Company_Id).ToList();



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
            var data = db.Portfolio_Agile_Lab.Where(x => x.Pal_Id == id).Include(p => p.Company).Include(p => p.Portfolio).Select(x => new

                 PortfolioAgileLabTO()
            {

                Company_Id = x.Company_Id,
                Current_Usage = x.Current_Usage,
                Future_Scope = x.Future_Scope,
                IsMarketLead = x.IsMarketLead,
                Pal_Id = x.Pal_Id,
                Portfolio_Id = x.Portfolio_Id
            }).FirstOrDefault();
            return data;
        }

        public void DeletePAL(int? id)
        {
            Portfolio_Agile_Lab portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Where(x=>x.Pal_Id==id).FirstOrDefault();
            db.Portfolio_Agile_Lab.Remove(portfolio_Agile_Lab);
            db.SaveChanges();
        }



        public void Update_Portfolio_Agile_LabData(int PortfolioId, string Curr_Usg, bool FutrFcsd, bool IsMrktLd, int CompanyId)
        {
            Portfolio_Agile_Lab portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Where(x => x.Company_Id == CompanyId && x.Portfolio_Id == PortfolioId).FirstOrDefault();

            portfolio_Agile_Lab.Current_Usage = Convert.ToInt16(Curr_Usg);
            portfolio_Agile_Lab.Future_Scope = FutrFcsd;
            portfolio_Agile_Lab.IsMarketLead = IsMrktLd;


            db.SaveChanges();
        }


        public void savePALData(PortfolioAgileLabTO dataTOsave)
        {
            Portfolio_Agile_Lab dataTosave = new Portfolio_Agile_Lab()
            {
                Company_Id = dataTOsave.Company_Id,
                Current_Usage = dataTOsave.Current_Usage,
                Future_Scope = dataTOsave.Future_Scope,
                IsMarketLead = dataTOsave.IsMarketLead,
                Pal_Id = dataTOsave.Pal_Id,
                Portfolio_Id = dataTOsave.Portfolio_Id
            };


            try
            {
                db.Portfolio_Agile_Lab.Add(dataTosave);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }



        public bool CheckIfPortfolio_CompanyExist(int Portfolio_Id, int Company_Id)
        {
            var Data = db.Portfolio_Agile_Lab.Where(x => x.Portfolio_Id == Portfolio_Id && x.Company_Id == Company_Id).Select(x => x.Company_Id);
            if (Data.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)

            {

                if (disposing)

                {

                    db.Dispose();

                }

            }

            this.disposed = true;
        }
        public void Dispose()

        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }
    }
}