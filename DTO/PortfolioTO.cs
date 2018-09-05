using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PortfolioTO
    {
        public int Portfolio_Id { get; set; }

        //[Required(ErrorMessage = "Portfolio Name is required")]
        public string Portfolio_Name { get; set; }
        public int Portfolio_Type_Id { get; set; }

        public string Portfolio_Type_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
