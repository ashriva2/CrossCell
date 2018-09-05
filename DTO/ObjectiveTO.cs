using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DTO
{
    public class ObjectiveTO
    {
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



        //public List<CompanyTO> Company { get; set; }
        //public List<QuestionerTO> Questioner { get; set; }
        //public List<SectionsTO> Metadata { get; set; }
    }
}
