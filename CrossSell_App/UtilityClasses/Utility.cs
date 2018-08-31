using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using CrossSell_App.DataAccess;
using System.Web.Mvc;
using CrossSell_App.Models;
using DataAccessLayer;

namespace CrossSell_App.UtilityClasses
{
    public class Utility
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        UserCompaniesInfo userComapniesData = new UserCompaniesInfo();
        public UserCompaniesInfo getUsercompanyInfo()
        {
            
            List<Company> CompanyList = new List<Company>();
            List<Int32> companyIds = new List<Int32>();
            if (HttpContext.Current.Session["companyId"] != null)
            {
                companyIds = (List<Int32>)HttpContext.Current.Session["companyId"];
                foreach (var item in companyIds)
                CompanyList.Add(db.Companies.Where(x => x.Company_Id == item).FirstOrDefault());
                userComapniesData.comPanies = CompanyList;

                userComapniesData.companyId = companyIds;
                return userComapniesData;
            }

            else

                return userComapniesData;
        }



        //public List<Company> getUsercompanyList()
        //{
        //    List<Company> CompanyList = new List<Company>();
        //    List<Int32> companyIds = new List<Int32>();
        //    if (HttpContext.Current.Session["companyId"] != null)
        //    {
        //        companyIds = (List<Int32>)HttpContext.Current.Session["companyId"];
        //        foreach (var item in companyIds)
        //            CompanyList.Add(db.Companies.Where(x => x.Company_Id == item).FirstOrDefault());
        //        return CompanyList;
        //    }
        //    else

        //        return CompanyList;
        //}

    }
}