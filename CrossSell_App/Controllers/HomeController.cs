using CrossSell_App.DataAccess;
using CrossSell_App.Models;
using CrossSell_App.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Caching;
using CrossSell_App.Repository;
using CrossSell_App.Repositories;

namespace CrossSell_App.Controllers
{
    public class HomeController : Controller
    {
        private HomeRepository homeRepo = new HomeRepository();
        private Utility utilObj = new Utility();

        static UserCompaniesInfo userComapniesData;


        public ActionResult Index()
        {
            userComapniesData = utilObj.getUsercompanyInfo();
            return View();
        }


        public ActionResult DPBReport(string CompList)
        {
            if (CompList != null)
            {
                List<int> result = System.Web.Helpers.Json.Decode<List<int>>(CompList);


                var coList = FillCompanyDropDown();
                //var companyList = db.Companies.Where(c => result.Contains(c.Company_Id)).Select(x => x.Company_Id).ToList();

                var companyList = homeRepo.GetCompanies().Where(c => result.Contains(c.Company_Id)).Select(x => new { x.Company_Name, x.Company_Id }).ToList();
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

            return View("DPBReport");
        }


        public ActionResult PALReport(string CompList)
        {
            if (CompList != null)
            {
                List<int> result = new List<int>();
                if (CompList.Contains("["))
                {
                    result = System.Web.Helpers.Json.Decode<List<int>>(CompList);
                }

                else
                {
                    result = CompList.Split(',').Select(Int32.Parse).ToList();
                }

                var coList = FillCompanyDropDown();
                //var companyList = db.Companies.Where(c => result.Contains(c.Company_Id)).Select(x => x.Company_Id).ToList();

                var companyList = homeRepo.GetCompanies().Where(c => result.Contains(c.Company_Id)).Select(x => new { x.Company_Name, x.Company_Id }).ToList();
                ViewBag.CompanyList = companyList;
                List<SelectListItem> listItems = new List<SelectListItem>();
                //if (CompList.Contains("["))
                //{
                    foreach (var item in companyList)
                    {
                        listItems.Add(new SelectListItem
                        {
                            Text = item.Company_Name,
                            Value = Convert.ToString(item.Company_Id),
                        });


                    }
                    ViewBag.fillCompanyddl = listItems;
                //}
                //else
                //{
                //    ViewBag.fillCompanyddl = FillCompanyDropDown();
                //}
            }
            else
            {
                ViewBag.fillCompanyddl = FillCompanyDropDown();
            }

            return View("PALReport");
        }




        public ActionResult CustomerHome()
        {
            return View();
        }




        public JsonResult GetData(List<int> compList)
        {

            List<int>[] a = new List<int>[100];
            List<string>[] IsLeadOrTobe = new List<string>[100];

            //var DataFromPAL = db.Portfolio_Agile_Lab.ToList().OrderBy(x => x.Portfolio_Id);
            var DataFromPAL = homeRepo.GetPALData();

            //need to check the number of company present
            if (compList != null && compList.Count > 0)
            {
                DataFromPAL = DataFromPAL.Where(x => compList.Contains(x.Company_Id)).ToList();
            }

            var PortfoliosList = homeRepo.GetPortfolios();
            //logic for company wise

            List<Company> CompanyList = new List<Company>();
            List<Int32> companyIds = new List<Int32>();
            List<string> companyColor = new List<string>();
            // userComapniesData = utilObj.getUsercompanyInfo();
            if (compList != null)
            {
                CompanyList = homeRepo.GetCompanies().Where(x => compList.Contains(x.Company_Id)).ToList();

            }
            else
            {
                if (userComapniesData.companyId != null && userComapniesData.companyId.Count > 0)
                {
                    //int id = Convert.ToInt16(Session["companyId"]);
                    CompanyList = userComapniesData.comPanies;
                    companyIds = userComapniesData.companyId;
                    ViewBag.companyIds = userComapniesData.companyId;

                }
                else
                {
                    CompanyList = homeRepo.GetCompanies();
                }

            }
            companyColor = CompanyList.Select(x => x.CompanyColor).ToList();
            int countOfUsage = 0;
            int countOfLeadsToBe = 0;
            //filter all the list of Current Usage
            foreach (var item in CompanyList)
            {

                List<int> CurrentUsagePerCompany = new List<int>();
                var dalfromPal = DataFromPAL.Where(x => x.Company_Id == item.Company_Id).Select(x => x.Current_Usage).ToList();

                //foreach (var data in DataFromPAL)
                //{
                //    if (item.Company_Id == data.Company_Id)
                //        CurrentUsagePerCompany.Add(data.Current_Usage);

                //}
                a[countOfUsage] = dalfromPal;// CurrentUsagePerCompany;
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

            object FinalChartDataSeries = new { a = a, IsLeadOrTobe = IsLeadOrTobe, companyColor = companyColor };





            return Json(FinalChartDataSeries, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDPBReportData(List<int> compList)
        {
            var objectivesList = homeRepo.GetAllObjectives();
            List<Company> CompanyList = new List<Company>();
            List<Int32> companyIds = new List<Int32>();
            List<string> companyColor = new List<string>();
            if (userComapniesData.companyId != null && userComapniesData.companyId.Count > 0)
            {
                CompanyList = userComapniesData.comPanies;
                ViewBag.companyIds = userComapniesData.companyId;
            }
            else
            {
                CompanyList = homeRepo.GetCompanies();
            }
            //CompanyList = db.Companies.ToList();
            //var companyList = db.Companies.ToList();
            // var metaDataList = db.Metadatas.Where(x => x.Metadata_Id != 7).OrderBy(x => x.Metadata_Id).ToList();
            var metaDataList = homeRepo.GetMetadatas();
            int count = 0;
            List<double?>[] dataseries = new List<double?>[100];
            List<double?> customerSeries = new List<double?>();

            if (compList != null && compList.Count > 0)
            {
                var selectedComp = homeRepo.GetAllObjectives().Where(x => compList.Contains(x.Company_Id)).ToList();
                CompanyList = CompanyList.Where(x => compList.Contains(x.Company_Id)).ToList();
                if (selectedComp != null && selectedComp.Count > 0)
                {
                    companyColor = CompanyList.Select(x => x.CompanyColor).ToList();
                    foreach (var co in compList)
                    {
                        customerSeries = new List<double?>();
                        foreach (var meta in metaDataList)
                        {
                            var obj = selectedComp.Where(x => x.Metadata_Id == meta.Metadata_Id && x.Company_Id == co).Select(t => t.Score_Max).Sum();
                            obj = Math.Round((Double)obj, 2);
                            customerSeries.Add(obj);
                        }
                        dataseries[count] = customerSeries;

                        count++;
                    }
                }
            }
            else
            {
                companyColor = CompanyList.Select(x => x.CompanyColor).ToList();
                foreach (var cmp in CompanyList)
                {
                    var companyObjectives = objectivesList.Where(t => t.Company_Id == cmp.Company_Id).ToList();
                    customerSeries = new List<double?>();

                    foreach (var mtdata in metaDataList)
                    {
                        var metadata = companyObjectives.Where(x => x.Metadata_Id == mtdata.Metadata_Id).Select(t => t.Score_Max).Sum();
                        metadata = Math.Round((Double)metadata, 2);
                        customerSeries.Add(metadata);

                    }

                    dataseries[count] = customerSeries;

                    count++;
                }

            }


            object FinalChartDataSeries = new { dataseries = dataseries, companyColor = companyColor };

            return Json(FinalChartDataSeries, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> FillCompanyDropDown()
        {

            List<SelectListItem> listItems = new List<SelectListItem>();

            // var companyList = db.Companies.ToList();
            List<Company> CompanyList = new List<Company>();
            List<Int32> companyIds = new List<Int32>();


            if (userComapniesData.companyId == null)
            {

                CompanyList = homeRepo.GetCompanies();
            }
            else
            {
                CompanyList = userComapniesData.comPanies;
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


        public ActionResult GetUserCompanies()
        {



            //  object CompanyInfo = new { companyIds = companyIds, CompanyList = CompanyList };
            return Json(userComapniesData.companyId, JsonRequestBehavior.AllowGet);
        }
    }
}
