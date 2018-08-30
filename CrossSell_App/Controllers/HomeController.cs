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

        public ActionResult PALReport(string CompList)
        {
            if (CompList != null)
            {
                List<int> result = System.Web.Helpers.Json.Decode<List<int>>(CompList);


                var coList = FillCompanyDropDown();
                //var companyList = db.Companies.Where(c => result.Contains(c.Company_Id)).Select(x => x.Company_Id).ToList();

                var companyList = db.Companies.Where(c => result.Contains(c.Company_Id)).Select(x => new { x.Company_Name, x.Company_Id }).ToList();
                ViewBag.CompanyList = companyList;
                List<SelectListItem> listItems = new List<SelectListItem>();
                foreach (var item in companyList)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item.Company_Name,
                        Value = Convert.ToString(item.Company_Id),
                    });


                }
                ViewBag.fillCompanyddl = listItems;
            }
            else
            {
                ViewBag.fillCompanyddl = FillCompanyDropDown();
            }

            return View("PALReport");
        }

        public ActionResult DPBReport()
        {
            ViewBag.fillCompanyddl = FillCompanyDropDown();
            return View();
        }

        public ActionResult CustomerHome()
        {
            return View();
        }




        public JsonResult GetData(List<int> compList)
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

            var DataFromPAL = db.Portfolio_Agile_Lab.ToList().OrderBy(x => x.Portfolio_Id);
            if (compList != null && compList.Count>0)
            {
                DataFromPAL = DataFromPAL.Where(x => compList.Contains(x.Company_Id)).ToList().OrderBy(x => x.Portfolio_Id);
            }
            //need to check the number of company present


            var PortfoliosList = db.Portfolios.ToList();
            //logic for company wise
            List<Company> CompanyList = new List<Company>();
            if (compList != null) {
                CompanyList = db.Companies.Where(x => compList.Contains(x.Company_Id)).ToList();
            }
            else
            {
                if (Session["companyId"] != null)
                {
                    int id = Convert.ToInt16(Session["companyId"]);
                    //do something interesting
                    CompanyList = db.Companies.Where(x => x.Company_Id == id).ToList();
                }
                else
                {
                    CompanyList = db.Companies.ToList();
                }
            }
            int countOfUsage = 0;
            int countOfLeadsToBe = 0;
            //filter all the list of Current Usage
            foreach (var item in CompanyList)
            {

                List<int> CurrentUsagePerCompany = new List<int>();
                foreach (var data in DataFromPAL)
                {
                    if (item.Company_Id == data.Company_Id)
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
                        if (data.IsMarketLead == true)

                            IsMarketLead = "*";

                        else
                            IsMarketLead = "";

                        if (data.Future_Scope == true)

                            IsFutureScope = "+";

                        else
                            IsFutureScope = "";

                        //string IsMarketLead= data.IsMarketLead ? true ? "*" : "":"";
                        //string IsFutureScope=data.Future_Scope ? true ? "+" : "":"";


                        CurrentUsagePerCompany.Add(IsMarketLead + IsFutureScope);
                    }

                }
                IsLeadOrTobe[countOfLeadsToBe] = CurrentUsagePerCompany;
                countOfLeadsToBe++;
            }

            var FinalChartDataSeries = new { a = a, IsLeadOrTobe = IsLeadOrTobe };

            //return Json(new
            //{
            //    a = a,
            //    IsLeadOrTobe = IsLeadOrTobe,
            //    PortfoliosList= PortfoliosList
            //},JsonRequestBehavior.AllowGet);

            return Json(FinalChartDataSeries, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDPBReportData()
        {
            var objectivesList = db.Objectives.ToList();
            List<Company> CompanyList = new List<Company>();

            if (Session["companyId"] != null)
            {
                int id = Convert.ToInt16(Session["companyId"]);
                //do something interesting

                CompanyList = db.Companies.Where(x => x.Company_Id == id).ToList();
            }
            else
            {
                CompanyList = db.Companies.ToList();
            }
            //CompanyList = db.Companies.ToList();
            //var companyList = db.Companies.ToList();
            var metaDataList = db.Metadatas.Where(x => x.Metadata_Id != 7).OrderBy(x => x.Metadata_Id).ToList();
            int count = 0;
            List<double?>[] dataseries = new List<double?>[100];


            foreach (var cmp in CompanyList)
            {
                var companyObjectives = objectivesList.Where(t => t.Company_Id == cmp.Company_Id).ToList();

                List<double?> customerSeries = new List<double?>();
                foreach (var mtdata in metaDataList)
                {
                    var metadata = companyObjectives.Where(x => x.Metadata_Id == mtdata.Metadata_Id).Select(t => t.Score_Max).Sum();
                    metadata = Math.Round((Double)metadata, 2);
                    customerSeries.Add(metadata);

                }

                dataseries[count] = customerSeries;

                count++;
            }



            return Json(dataseries, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> FillCompanyDropDown()
        {

            List<SelectListItem> listItems = new List<SelectListItem>();

            // var companyList = db.Companies.ToList();
            List<Company> CompanyList = new List<Company>();
            if (Session["companyId"] != null)
            {
                int id = Convert.ToInt16(Session["companyId"]);
                //do something interesting
                CompanyList = db.Companies.Where(x => x.Company_Id == id).ToList();
            }
            else
            {

                CompanyList = db.Companies.ToList();
            }

            foreach (var item in CompanyList)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Company_Name,
                    Value = Convert.ToString(item.Company_Id),
                });


            }


            return listItems;
        }
    }
}
