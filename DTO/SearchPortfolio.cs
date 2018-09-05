using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SearchPortfolio
    {
        public string PortfolioName { get; set; }
        public int PortfolioId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int CurrentUsage { get; set; }

    }
}
