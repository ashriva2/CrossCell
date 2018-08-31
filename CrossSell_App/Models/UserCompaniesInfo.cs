//using CrossSell_App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace CrossSell_App.Models
{
    public class UserCompaniesInfo
    {
        public List<Int32> companyId { get; set; }
        public List<Company> comPanies { get; set; }
    }
}