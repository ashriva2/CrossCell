using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataAccessLayer.Repositories
{
    public class QuestionerRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        public List<Questioner> getAllQuestioner()
        {
            return db.Questioners.Where(x => x.IsActive == true).ToList();

           // return  db.Questioners.Where(x => x.IsActive == true).Include(x => x.Metadata).Select(x=>
           //new QuestionerTO()
           //{
           //     Questioner_Id=x.Questioner_Id,
           //      IsActive=x.IsActive,
           //       Metadata_Id=x.Metadata_Id,
           //       Questioner1=x.Questioner1

            //}).ToList();
        }

        public Questioner getQuestionerbyId(int? id)
        {
            return db.Questioners.Where(x => x.Questioner_Id == id).FirstOrDefault();
          //  return db.Questioners.Where(x => x.Questioner_Id == id).Select(x =>
          //new QuestionerTO()
          //{
          //    Questioner_Id = x.Questioner_Id,
          //    IsActive = x.IsActive,
          //    Metadata_Id = x.Metadata_Id,
          //    Questioner1 = x.Questioner1

            //}).FirstOrDefault();

        }

        public List<Metadata> getAllMetadata()
        {

            return db.Metadatas.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Metadata_Id).ToList();
            //var data = db.Metadatas.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Metadata_Id).ToList();



            //var dataToReturn = data.Select(p => new MetadataTO()
            //{
            //    Metadata_Name = p.Metadata_Name,
            //    Metadata_Id = p.Metadata_Id,
            //    IsActive = p.IsActive

            //}).ToList();

            //return dataToReturn;
        }

        public void saveQuestioners(Questioner question)
        {
            Questioner dataToSave = new Questioner()
            {
                Questioner1 = question.Questioner1,
                Metadata_Id = question.Metadata_Id,
                IsActive = true
            };
            db.Questioners.Add(dataToSave);
            db.SaveChanges();

        }

        public void updateQuestioner(Questioner question)
        {
            Questioner dataToUpdate = db.Questioners.Where(x => x.Questioner_Id == question.Questioner_Id).FirstOrDefault();
          
            dataToUpdate.Questioner1 = question.Questioner1;
            dataToUpdate.Metadata_Id = question.Metadata_Id;
            dataToUpdate.IsActive = question.IsActive;


            db.SaveChanges();

        }


        public void deleteQuestion(int id)
        {
            Questioner Question = db.Questioners.Find(id);
            Question.IsActive = false;
            //db.Questioners.Remove(Question);
            db.SaveChanges();
        }

    }
}
