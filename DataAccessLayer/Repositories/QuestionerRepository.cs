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
        public IQueryable<Questioner> getAllQuestioner()
        {
            return  db.Questioners.Include(x => x.Metadata);
        }

        public Questioner getQuestionerbyId(int? id)
        {
            return db.Questioners.Where(x => x.Questioner_Id == id).FirstOrDefault();

        }

        public List<Metadata> getAllMetadata()
        {
            return db.Metadatas.ToList();

        }

        public void saveQuestioners(Questioner question)
        {
            db.Questioners.Add(question);
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
            db.Questioners.Remove(Question);
            db.SaveChanges();
        }

    }
}
