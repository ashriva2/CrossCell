using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossSell_App.Models
{
    public class MetadataTO
    {
        public MetadataTO()
        {
            //this.Questioners = new HashSet<QuestionerTO>();
            //this.Objectives = new HashSet<ObjectiveTO>();
        }

        public int Metadata_Id { get; set; }

        [Required(ErrorMessage = "Section name is required")]
        public string Metadata_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<QuestionerTO> Questioners { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ObjectiveTO> Objectives { get; set; }
    }
}
