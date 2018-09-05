using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PortfolioTypeTO
    {
        public int Portfolio_Type_Id { get; set; }
        public string Portfolio_Type_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
