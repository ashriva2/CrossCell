using CrossSell_App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Models
{
    public class ObjectivesModel
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        public int Objective_Id { get; set; }   
        public string Comments { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<double> Score_Max { get; set; }
        public Nullable<int> Max { get; set; }
        public Nullable<int> Answer { get; set; }
        public Nullable<int> Score { get; set; }
        public string Level { get; set; }
        public int Metadata_Id { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int Questioner_Id { get; set; }
        public int Company_Id { get; set; }

        public string QuestionText { get; set; }
        public string MetaDataText { get; set; }



        public List<Company> Company { get; set; }
        public List<Questioner> Questioner { get; set; }
        public List<SectionModel> Metadata { get; set; }

        //public ObjectivesModel()
        //{
        //    Company = db.Companies.ToList();
        //    Questioner = db.Questioners.ToList();
            
        //}


    }
}