using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PalDetailMapping
    {
        public List<PortfolioTypeTO> portfolioTypeList { get; set; }
        public List<PortfolioTO> portfolioList { get; set; }
        public List<PortfolioAgileLabTO> portfolioAgileLab { get; set; }
        public List<CompanyTO> companyList { get; set; }
    }
}
