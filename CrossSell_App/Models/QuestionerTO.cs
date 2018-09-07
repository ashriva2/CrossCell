using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossSell_App.Models
{
   public class QuestionerTO
    {
        public QuestionerTO()
        {
            this.Objectives = new HashSet<ObjectiveTO>();
        }

        public int Questioner_Id { get; set; }
        public int Metadata_Id { get; set; }
        [Required(ErrorMessage = "Questions is required")]
        public string Questioner1 { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual MetadataTO Metadata { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectiveTO> Objectives { get; set; }
    }
}
