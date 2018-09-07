
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Repositories;
using CrossSell_App.Repository;

namespace Services
{
    public class ObjectivesService
    {
        private ObjectivesRepository repo = new ObjectivesRepository();
        private bool disposed = false;

        public List<Company> GetCompanies()
        {
            //var data = db.Companies.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Company_Id).ToList();


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
            //    Metadata_Name = p.Metadata_Name,
            //    Metadata_Id = p.Metadata_Id,
            //    IsActive = p.IsActive

            //}).ToList();

            //return dataToReturn;
        }
        public List<Objective> GetAllObjectives()
        {
           return GetAllObjectives();

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

       
        public void SaveObjective(Objective p)
        {

            repo.SaveObjective(p);
          //Objective datatoSave= new Objective()
          //  {
          //      Answer = p.Answer,
          //      Comments = p.Comments,
          //      Company_Id = p.Company_Id,
          //      IsActive = p.IsActive,
          //      Level = p.Level,
          //      Max = p.Max,
          //      Metadata_Id = p.Metadata_Id,
          //      Objective_Id = p.Objective_Id,
          //      Questioner_Id = p.Questioner_Id,
          //      Score = p.Score,
          //      Score_Max = p.Score_Max,
          //      Weight = p.Weight
          //  };
          //  try
          //  {
          //      db.Objectives.Add(datatoSave);
          //      db.SaveChanges();
          //  }
          //  catch(Exception ex)
          //  {

          //  }
        }

        public List<Objective> getObjectivebyCompany(int? companyid)
        {
            return repo.getObjectivebyCompany(companyid);
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


        public void UpdateObjective(Objective item)
        {

            repo.UpdateObjective(item);
            //Objective saveData = new Objective()
            //{
                
            //    Comments = item.Comments,
            //    Level = item.Level,
            //    Score = item.Score,
            //    Score_Max = item.Score_Max,
            //    Max = item.Max,
            //    Weight = item.Weight,
            //    Answer = item.Answer



            //};

            //try
            //{
               
            //    db.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //}
        }
        public List<Questioner> getAllQuestioner()
        {
            return repo.getAllQuestioner();
            //return db.Questioners.Where(x=>x.IsActive==true).Include(x => x.Metadata).Select(x =>
            //new QuestionerTO()
            //{
            //    Questioner_Id = x.Questioner_Id,
            //    IsActive = x.IsActive,
            //    Metadata_Id = x.Metadata_Id,
            //    Questioner1 = x.Questioner1

            //}).ToList();
        }


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