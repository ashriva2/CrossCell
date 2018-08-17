using CrossSell_App.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CrossSell_App.Controllers
{
    public class HomeController : Controller
    {

        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PALReport()
        {
            return View();
        }

        public ActionResult DPBReport()
        {
            return View();
        }

        public ActionResult CustomerHome()
        {
            return View();
        }

        public JsonResult GetData()
        {
            //var jsonData = "{'labels': [0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 50]," +
            //             "'data': [90, 80, 60, 80, 90, 0, 0, 0, 0, 0, 0]" +
            //             "'data2':[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]" +
            //             "'data3':[90, 0, 60, 80, 90, 0, 0, 0, 70, 0, 0]" +
            //             "'data4':[90, 0, 0, 80, 0, 0, 0, 0, 70, 0, 90]" +
            //             "'labels2':['*+', '+', '', '+', '', '', '', '', '', '', '', '']" +
            //             "'labels3':['', '', '', '', '', '', '', '', '', '', '', '']" +
            //             "'labels4':['*', '', '+', '+', '+', '', '', '', '*+', '', '']" +
            //             "'labels5':['+', '', '', '+', '+', '', '+', '+', '+', '', '+']" +
            //             "'yLable': ['NextGen AMS', 'NextGen SAP', 'DCX', 'Cloud', 'CyberSecurity', 'Digital Mfg', 'AI', 'Chatbots', 'Devops', 'Blockchain', 'End to End Offering']}";

            //Array of List 

            List<int>[] a = new List<int>[100];
            List<string>[] IsLeadOrTobe = new List<string>[100];

            var DataFromPAL = db.Portfolio_Agile_Lab.ToList().OrderBy(x=>x.Portfolio_Id);
            //need to check the number of company present


            var PortfoliosList = db.Portfolios.ToList();
            var CompanyList = db.Companies.ToList();
            int countOfUsage = 0;
            int countOfLeadsToBe = 0;
            //filter all the list of Current Usage
            foreach (var item in CompanyList)
            {
                
                List<int> CurrentUsagePerCompany = new List<int>();
                foreach(var data in DataFromPAL)
                {
                    if(item.Company_Id== data.Company_Id)
                    CurrentUsagePerCompany.Add(data.Current_Usage);
                    
                }
                a[countOfUsage] = CurrentUsagePerCompany;
                countOfUsage++;
            }

            //filter all the list of Labels for * and +
            foreach (var item in CompanyList)
            {
               
                List<string> CurrentUsagePerCompany = new List<string>();
                foreach (var data in DataFromPAL)
                {
                    if (item.Company_Id == data.Company_Id)
                    {
                        string IsMarketLead;
                        string IsFutureScope;
                        if (data.IsMarketLead==true)
                      
                            IsMarketLead = "*";
                        
                        else
                            IsMarketLead = "";

                        if (data.Future_Scope == true)

                            IsFutureScope = "+";

                        else
                            IsFutureScope = "";

                        //string IsMarketLead= data.IsMarketLead ? true ? "*" : "":"";
                        //string IsFutureScope=data.Future_Scope ? true ? "+" : "":"";


                        CurrentUsagePerCompany.Add(IsMarketLead+ IsFutureScope);
                    }
                    
                }
                IsLeadOrTobe[countOfLeadsToBe] = CurrentUsagePerCompany;
                countOfLeadsToBe++;
            }

            var FinalChartDataSeries = new { a = a, IsLeadOrTobe = IsLeadOrTobe};

            //return Json(new
            //{
            //    a = a,
            //    IsLeadOrTobe = IsLeadOrTobe,
            //    PortfoliosList= PortfoliosList
            //},JsonRequestBehavior.AllowGet);

            return Json(FinalChartDataSeries, JsonRequestBehavior.AllowGet);
        }



    }
}
