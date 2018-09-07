using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Models
{
    public class SectionModel
    {
        public int Metadata_Id { get; set; }
       
        public string Metadata_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
}