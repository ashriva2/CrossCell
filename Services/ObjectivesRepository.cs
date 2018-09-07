
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DTO;

namespace CrossSell_App.Repository
{
    public class ObjectivesRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        private bool disposed = false;

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
            var data = db.Metadatas.Where(x=>x.IsActive==true).ToList().OrderBy(x => x.Metadata_Id).ToList();



            var dataToReturn = data.Select(p => new MetadataTO()
            {
                Metadata_Name = p.Metadata_Name,
                Metadata_Id = p.Metadata_Id,
                IsActive = p.IsActive

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

       
        public void SaveObjective(ObjectiveTO p)
        {
          Objective datatoSave= new Objective()
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
                Weight = p.Weight
            };
            try
            {
                db.Objectives.Add(datatoSave);
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public List<ObjectiveTO> getObjectivebyCompany(int? companyid)
        {
            var data = db.Objectives.Where(x=>x.Company_Id==companyid).ToList().OrderBy(x => x.Metadata_Id).ToList();
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


        public void UpdateObjective(ObjectiveTO item)
        {
            Objective saveData = new Objective()
            {
                
                Comments = item.Comments,
                Level = item.Level,
                Score = item.Score,
                Score_Max = item.Score_Max,
                Max = item.Max,
                Weight = item.Weight,
                Answer = item.Answer



            };

            try
            {
               
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public List<QuestionerTO> getAllQuestioner()
        {
            return db.Questioners.Where(x=>x.IsActive==true).Include(x => x.Metadata).Select(x =>
            new QuestionerTO()
            {
                Questioner_Id = x.Questioner_Id,
                IsActive = x.IsActive,
                Metadata_Id = x.Metadata_Id,
                Questioner1 = x.Questioner1

            }).ToList();
        }


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