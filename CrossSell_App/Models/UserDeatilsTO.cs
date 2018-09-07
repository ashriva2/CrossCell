using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossSell_App.Models
{
    public class UserDeatilsTO
    {
        
        [Required(ErrorMessage= "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password  is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string roles { get; set; }
    }
}
