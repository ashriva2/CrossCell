
//using CrossSell_App.DataAccess;
using DataAccessLayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using DataAccessLayer;
using DataAccessLayer.Repositories;


namespace Services
{
    public class HomeService
    {

        private HomeRepository repo = new HomeRepository();

        public List<Portfolio_Agile_Lab> GetPALData()
        {
            var data= repo.GetPALData();

            var dataToReturn = data.Select(x => new Portfolio_Agile_Lab()
            {

                Company_Id = x.Company_Id,
                Current_Usage = x.Current_Usage,
                Future_Scope = x.Future_Scope,
                IsMarketLead = x.IsMarketLead,
                Pal_Id = x.Pal_Id,
                Portfolio_Id = x.Portfolio_Id

            }).ToList();
            return dataToReturn;
        }

        public List<Portfolio_Agile_Lab> GetPALDatabyCompanyList(List<int> comapanylst)
        {
            return repo.GetPALDatabyCompanyList(comapanylst);

                //new PortfolioAgileLabTO()
                //{
                //    Company_Id = x.Company_Id,
                //    Current_Usage = x.Current_Usage,
                //    Future_Scope = x.Future_Scope,
                //    IsMarketLead = x.IsMarketLead,
                //    Pal_Id = x.Pal_Id,
                //    Portfolio_Id = x.Portfolio_Id
                //}).ToList();
        }

        public List<Portfolio> GetPortfolios()
        {
            return repo.GetPortfolios();

            //var dataToReturn = data.Select(x => new PortfolioTO
            //{
            //    Portfolio_Id = x.Portfolio_Id,
            //    Portfolio_Name = x.Portfolio_Name,
            //    Portfolio_Type_Id = x.Portfolio_Type_Id

            //});
            //return dataToReturn.ToList();
        }

        public List<Company> GetCompanies()
        {

            return repo.GetCompanies();



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


        public List<Metadata> GetMetadatas()
        {
            return repo.GetMetadatas();



            //var dataToReturn = data.Select(p => new MetadataTO()
            //{
            //     Metadata_Name=p.Metadata_Name,
            //     Metadata_Id=p.Metadata_Id,
            //     IsActive=p.IsActive
               
            //}).ToList();

            //return dataToReturn;
        }
        public List<Objective> GetAllObjectives()
        {
            return repo.GetAllObjectives();

            //var dataToReturn = data.Select(p => new ObjectiveTO()
            //{
            //    Answer = p.Answer,
            //    Comments = p.Comments,
            //    Company_Id = p.Company_Id,
            //    IsActive = p.IsActive,
            //    Level = p.Level,
            //    Max = p.Max,
            //    Metadata_Id = p.Metadata_Id,
            //    Objective_Id = p.Objective_Id,
            //    Questioner_Id = p.Questioner_Id,
            //    Score = p.Score,
            //    Score_Max = p.Score_Max,
            //    Weight = p.Weight,
            //}).ToList();

            //return dataToReturn;
        }

        //private bool disposed = false;
        //public void Dispose(bool disposing)
        //{
        //    if (!this.disposed)

        //    {

        //        if (disposing)

        //        {

        //            db.Dispose();

        //        }

        //    }

        //    this.disposed = true;
        //}
        //public void Dispose()

        //{

        //    Dispose(true);

        //    GC.SuppressFinalize(this);

        //}
    }
}