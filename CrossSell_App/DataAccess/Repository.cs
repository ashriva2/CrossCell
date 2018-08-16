using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.DataAccess
{
    public class Repository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        public bool CheckIfPortfolio_CompanyExist(int Portfolio_Id, int Company_Id)
        {
            var Data = db.Portfolio_Agile_Lab.Where(x => x.Portfolio_Id == Portfolio_Id && x.Company_Id == Company_Id).Select(x => x.Company_Id);
            if (Data.Count()>0)
            {
                return true;
            }
            else
                return false;
        }
    }
}