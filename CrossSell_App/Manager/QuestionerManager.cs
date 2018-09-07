using CrossSell_App.Models;
using DataAccessLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Manager
{
    public class QuestionerManager
    {
        private QuestionerService repo = new QuestionerService();
        public List<QuestionerTO> getAllQuestioner()
        {
            var data= repo.getAllQuestioner();
            var result= data.Select(x =>
          new QuestionerTO()
          {
              Questioner_Id = x.Questioner_Id,
              IsActive = x.IsActive,
              Metadata_Id = x.Metadata_Id,
              Questioner1 = x.Questioner1

          }).ToList();
            return result;
        }

        public QuestionerTO getQuestionerbyId(int? id)
        {
            var x= repo.getQuestionerbyId(id);
            //  return db.Questioners.Where(x => x.Questioner_Id == id).Select(x =>
            return new QuestionerTO()
            {
                Questioner_Id = x.Questioner_Id,
                IsActive = x.IsActive,
                Metadata_Id = x.Metadata_Id,
                Questioner1 = x.Questioner1

            };

        }

        public List<MetadataTO> getAllMetadata()
        {
            var data= repo.getAllMetadata();
            //var data = db.Metadatas.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Metadata_Id).ToList();



            var dataToReturn = data.Select(p => new MetadataTO()
            {
                Metadata_Name = p.Metadata_Name,
                Metadata_Id = p.Metadata_Id,
                IsActive = p.IsActive

            }).ToList();

            return dataToReturn;
        }

        public void saveQuestioners(QuestionerTO question)
        {
            Questioner dataToSave = new Questioner()
            {
                Questioner1 = question.Questioner1,
                Metadata_Id = question.Metadata_Id,
                IsActive = true
            };
           repo.saveQuestioners(dataToSave);
           
            //db.Questioners.Add(dataToSave);
            //db.SaveChanges();

        }

        public void updateQuestioner(QuestionerTO question)
        {
            Questioner dataToUpdate = new Questioner();
            dataToUpdate.Questioner_Id = question.Questioner_Id;
            dataToUpdate.Questioner1 = question.Questioner1;
            dataToUpdate.Metadata_Id = question.Metadata_Id;
            dataToUpdate.IsActive = question.IsActive;
            repo.updateQuestioner(dataToUpdate);
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