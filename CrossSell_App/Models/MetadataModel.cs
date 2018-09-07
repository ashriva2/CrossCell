//using CrossSell_App.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace CrossSell_App.Models
{
    public class MetadataModel
    {
        public MetadataModel()
        {
            this.Questioners = new HashSet<Questioner>();
            this.Objectives = new HashSet<Objective>();
        }

        public int Metadata_Id { get; set; }
        [Required(ErrorMessage = "Metadata  Name is required")]
        public string Metadata_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questioner> Questioners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Objective> Objectives { get; set; }
    }
}