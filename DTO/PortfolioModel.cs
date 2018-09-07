using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrossSell_App.Models
{
    public class PortfolioModel
    {
        
        public int Portfolio_Id { get; set; }

        [Required(ErrorMessage = "Portfolio Name is required")]
        public string Portfolio_Name { get; set; }
        public int Portfolio_Type_Id { get; set; }
    }
}