using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrossSell_App.DataAccess;

namespace CrossSell_App.Models
{
    public class PalDetailMapping
    {
        public List<Portfolio_Type> portfolioTypeList { get; set; }
        public List<DataAccess.Portfolio> portfolioList { get; set; }
        public List<Portfolio_Agile_Lab> portfolioAgileLab { get; set; }
        public List<Company> companyList { get; set; }
    }
}