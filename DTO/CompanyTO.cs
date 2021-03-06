﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CompanyTO
    {
        public CompanyTO()
        {
            //this.CrossSells = new HashSet<CrossSell>();
            //this.Objectives = new HashSet<ObjectiveTO>();
            //this.Portfolio_Agile_Lab = new HashSet<PortfolioAgileLabTO>();
            //this.UserAccesses = new HashSet<UserAccessTO>();
        }

        public int Company_Id { get; set; }
       
        public string Company_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Company_Admin { get; set; }
        public string Company_Contacts { get; set; }
        public string CompanyColor { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CrossSell> CrossSells { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ObjectiveTO> Objectives { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PortfolioAgileLabTO> Portfolio_Agile_Lab { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UserAccessTO> UserAccesses { get; set; }
    }
}
