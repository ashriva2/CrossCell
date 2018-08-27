using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Models
{
    public class SearchBySection
    {
        public string CompanyName { get; set; }
        public string SectionName { get; set; }
        
        public double Score_MAx { get; set; }
    }
}