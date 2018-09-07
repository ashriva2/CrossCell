//using CrossSell_App.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace CrossSell_App.Models
{
    public class CompanyModel
    {
        public CompanyModel()
        {
            this.CrossSells = new HashSet<CrossSell>();
            this.Objectives = new HashSet<Objective>();
            this.Portfolio_Agile_Lab = new HashSet<Portfolio_Agile_Lab>();
            this.UserAccesses = new HashSet<UserAccess>();
        }

        public int Company_Id { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public string Company_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Company_Admin { get; set; }
        public string Company_Contacts { get; set; }
        public string CompanyColor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CrossSell> CrossSells { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Objective> Objectives { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_Agile_Lab> Portfolio_Agile_Lab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAccess> UserAccesses { get; set; }
    }
}