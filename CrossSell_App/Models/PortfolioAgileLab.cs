using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Models
{
    public class PortfolioAgileLab
    {
        public int Company_Id { get; set; }
        public int Portfolio_Id { get; set; }
        public int Current_Usage { get; set; }
        public bool Future_Scope { get; set; }
        public bool IsMarketLead { get; set; }

    }
}