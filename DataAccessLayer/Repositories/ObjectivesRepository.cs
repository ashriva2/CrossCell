
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CrossSell_App.Repository
{
    public class ObjectivesRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        private bool disposed = false;

        public List<Company> GetCompanies()
        {
            return db.Companies.ToList().OrderBy(x => x.Company_Id).ToList();
        }
        public List<Metadata> GetMetadatas()
        {
            return db.Metadatas.ToList().Where(x => x.Metadata_Id != 7).OrderBy(x => x.Metadata_Id).ToList();
        }
        public List<Objective> GetAllObjectives()
        {
            return db.Objectives.OrderBy(x => x.Objective_Id).ToList();
        }

       
        public void SaveObjective(Objective item)
        {
            
            try
            {
                db.Objectives.Add(item);
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public List<Objective> getObjectivebyCompany(int? companyid)
        {
            return db.Objectives.Where(x => x.Company_Id == companyid).ToList();
        }


        public void UpdateObjective(Objective item)
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
        public IQueryable<Questioner> getAllQuestioner()
        {
            return db.Questioners.Include(x => x.Metadata);
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