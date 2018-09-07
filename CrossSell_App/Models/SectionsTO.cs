using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossSell_App.Models
{
    public class SectionsTO
    {
        public int Metadata_Id { get; set; }

        public string Metadata_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
