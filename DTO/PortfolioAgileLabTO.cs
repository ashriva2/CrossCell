using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PortfolioAgileLabTO
    {
        public int Pal_Id { get; set; }
        public int Company_Id { get; set; }
        public int Portfolio_Id { get; set; }
        public int Current_Usage { get; set; }
        public bool Future_Scope { get; set; }
        public bool IsMarketLead { get; set; }

        public virtual CompanyTO Company { get; set; }
        public virtual PortfolioTO Portfolio { get; set; }
    }
}
