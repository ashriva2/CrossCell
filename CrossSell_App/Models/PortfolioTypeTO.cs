using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossSell_App.Models
{
    public class PortfolioTypeTO
    {
        public int Portfolio_Type_Id { get; set; }
        [Required(ErrorMessage = "Portfolio Type name is required")]
        public string Portfolio_Type_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
