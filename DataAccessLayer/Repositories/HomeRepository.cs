﻿
//using CrossSell_App.DataAccess;
using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace CrossSell_App.Repositories
{
    public class HomeRepository:IDisposable
    {

        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        public List<PortfolioAgileLabTO> GetPALData()
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

        public List<PortfolioAgileLabTO> GetPALDatabyCompanyList(List<int> comapanylst)
        {
            return db.Portfolio_Agile_Lab.ToList().Where(c=>comapanylst.Contains(c.Company_Id)).OrderBy(x => x.Portfolio_Id).Select(x=>
                
                new PortfolioAgileLabTO()
                {
                    Company_Id = x.Company_Id,
                    Current_Usage = x.Current_Usage,
                    Future_Scope = x.Future_Scope,
                    IsMarketLead = x.IsMarketLead,
                    Pal_Id = x.Pal_Id,
                    Portfolio_Id = x.Portfolio_Id
                }).ToList();
        }

        public List<PortfolioTO> GetPortfolios()
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

        public List<CompanyTO> GetCompanies()
        {

            var data = db.Companies.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Company_Id).ToList();



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


        public List<MetadataTO> GetMetadatas()
        {
            var data = db.Metadatas.ToList().Where(x=>x.Metadata_Id!=7 && x.IsActive==true).OrderBy(x => x.Metadata_Id).ToList();



            var dataToReturn = data.Select(p => new MetadataTO()
            {
                 Metadata_Name=p.Metadata_Name,
                 Metadata_Id=p.Metadata_Id,
                 IsActive=p.IsActive
               
            }).ToList();

            return dataToReturn;
        }
        public List<ObjectiveTO> GetAllObjectives()
        {
            var data = db.Objectives.ToList().OrderBy(x => x.Metadata_Id).ToList();

            var dataToReturn = data.Select(p => new ObjectiveTO()
            {
                Answer = p.Answer,
                Comments = p.Comments,
                Company_Id = p.Company_Id,
                IsActive = p.IsActive,
                Level = p.Level,
                Max = p.Max,
                Metadata_Id = p.Metadata_Id,
                Objective_Id = p.Objective_Id,
                Questioner_Id = p.Questioner_Id,
                Score = p.Score,
                Score_Max = p.Score_Max,
                Weight = p.Weight,
            }).ToList();

            return dataToReturn;
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