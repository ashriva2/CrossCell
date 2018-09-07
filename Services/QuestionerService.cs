using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace Services
{
    public class QuestionerService
    {
        private QuestionerRepository repo = new QuestionerRepository();
        public List<Questioner> getAllQuestioner()
        {
            return repo.getAllQuestioner();
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
            return repo.getQuestionerbyId(id);
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
            return repo.getAllMetadata();
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
            repo.saveQuestioners(question);
            //Questioner dataToSave = new Questioner()
            //{
            //    Questioner1 = question.Questioner1,
            //    Metadata_Id = question.Metadata_Id,
            //    IsActive = true
            //};
            //db.Questioners.Add(dataToSave);
            //db.SaveChanges();

        }

        public void updateQuestioner(Questioner question)
        {
            repo.updateQuestioner(question);
            //Questioner dataToUpdate = db.Questioners.Where(x => x.Questioner_Id == question.Questioner_Id).FirstOrDefault();
          
            //dataToUpdate.Questioner1 = question.Questioner1;
            //dataToUpdate.Metadata_Id = question.Metadata_Id;
            //dataToUpdate.IsActive = question.IsActive;


            //db.SaveChanges();

        }


        public void deleteQuestion(int id)
        {
            repo.deleteQuestion(id);
            //Questioner Question = db.Questioners.Find(id);
            //Question.IsActive = false;
            ////db.Questioners.Remove(Question);
            //db.SaveChanges();
        }

    }
}
