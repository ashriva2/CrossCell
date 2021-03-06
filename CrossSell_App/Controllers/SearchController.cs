﻿//using CrossSell_App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Net;
using CrossSell_App.Models;
using CrossSell_App.Repositories;
using CrossSell_App.UtilityClasses;
using DataAccessLayer;
using DTO;

namespace CrossSell_App.Controllers
{
    public class SearchController : Controller
    {
        //private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        private HomeRepository homeRepo = new HomeRepository();
        private Utility utilObj = new Utility();
        // GET: Search
        public ActionResult SearchAlgorithm(string searchKey)
        {
            ViewBag.SearchText = searchKey;
            bool isProfolio = false;
            bool isSection = false;
            bool isSectionByName = false;
            bool isCompany = false;
            //Get the user from UserRole table
            //Get the useraccess from UserAccess table
            List<int> companyId = new List<int>();
           
            var userComapniesData = utilObj.getUsercompanyInfo();
            
            if (userComapniesData.companyId == null)
            {
                companyId = homeRepo.GetCompanies().Select(x => x.Company_Id).ToList();
            }
            else
            {
                companyId = userComapniesData.companyId;
            }
            //companyId.Add(1);
            //companyId.Add(2);
            //companyId.Add(3);

            companyId.Sort();
            var companyList = homeRepo.GetCompanies().Where(c => companyId.Contains(c.Company_Id)).Select(x => new { x.Company_Name, x.Company_Id }).OrderBy(x => x.Company_Id).ToList();
            
            Dictionary <  List<int>,string> companyObject = new Dictionary<List<int>, string>();

            List<string> cList = new List<string>();
            List<int> compIdList = new List<int>();
            foreach (var c in companyList)
            {
                cList.Add(c.Company_Name);
                compIdList.Add(c.Company_Id);
                List<int> ids = new List<int>();
                ids.Add(c.Company_Id);
                companyObject.Add(ids, c.Company_Name);
            }
            ViewBag.companyObject = companyObject;
            ViewBag.CompanyList = cList;
            ViewBag.CompanyIdList = compIdList;
            //Portfolio portfolio = db.Portfolios.Find(id);
            var portfolioList = homeRepo.GetPortfolios().ToList();

            var selectedCompanyList = companyList.Where(x => x.Company_Name.ToLower().Contains(searchKey.ToLower())).ToList();
           
            if (selectedCompanyList.Count > 0)
            {
                isCompany = true;
                ViewBag.PortFolioList = portfolioList;
                companyList = selectedCompanyList;
            }
            else if (searchKey.ToLower().Contains("report"))
            {
                isCompany = true;
            }

           

            if (("portfolio".Contains(searchKey.ToLower()) || "pal".Contains(searchKey.ToLower()) )&& !isCompany)
            {
                isProfolio = true;
                ViewBag.PortFolioList = portfolioList;

            }
            if (!isProfolio && !isCompany)
            {
                var portFolioCheck = portfolioList.Where(x => x.Portfolio_Name.ToLower().Contains(searchKey.ToLower())).ToList();
                if (portFolioCheck.Count > 0)
                {
                    isProfolio = true;
                    portfolioList = portFolioCheck;
                    ViewBag.PortFolioList = portfolioList;

                }
            }
            if (!isProfolio && !isCompany)
            {
                if (searchKey.ToLower().Contains("section") || searchKey.ToLower().Contains("dpb") || "digital".Contains(searchKey.ToLower()) || "picture".Contains(searchKey.ToLower()) || "benchmark".Contains(searchKey.ToLower()))
                {
                    var sectionCheck = homeRepo.GetMetadatas().ToList();
                    if (sectionCheck.Count > 0)
                    {
                        var sectionList = sectionCheck;
                        List<string> secList = new List<string>();
                        foreach (var sec in sectionList)
                        {
                            secList.Add(sec.Metadata_Name);
                        }
                        ViewBag.SectionName = secList;
                        isSection = true;
                    }
                }
                else if (!isSection && !isCompany)
                {
                    var sectionCheck = homeRepo.GetMetadatas().Where(x => x.Metadata_Name.ToLower().Contains(searchKey.ToLower())).ToList();
                    if (sectionCheck.Count > 0)
                    {
                        var sectionList = sectionCheck;
                        List<string> secList = new List<string>();
                        foreach (var sec in sectionList)
                        {
                            secList.Add(sec.Metadata_Name);
                        }
                        ViewBag.SectionName = secList;
                        isSectionByName = true;
                    }
                }

            }

            if (isCompany)
            {
                
                ViewBag.PortFolioList = portfolioList;
                var portfolio_Agile_Lab_byComp = homeRepo.GetPALData();


                SearchByCompany searchByComp = new SearchByCompany();
                List<SearchPortfolio> searchPortfolio = new List<SearchPortfolio>();

              
                List<SearchBySection> searchCompBySection = new List<SearchBySection>();

                cList = new List<string>();
                compIdList = new List<int>();
                companyObject = new Dictionary<List<int>, string>();
                foreach (var c in companyList)
                {
                    cList.Add(c.Company_Name);
                    compIdList.Add(c.Company_Id);
                    List<int> ids = new List<int>();
                    ids.Add(c.Company_Id);
                    companyObject.Add(ids, c.Company_Name);
                }
                ViewBag.companyObject = companyObject;
                ViewBag.CompanyList = cList;
                ViewBag.CompanyIdList = compIdList;
                var sectionCheck = homeRepo.GetMetadatas();
                if (sectionCheck.Count > 0)
                {
                    var sectionList = sectionCheck;
                    List<string> secList = new List<string>();
                    foreach (var sec in sectionList)
                    {
                        secList.Add(sec.Metadata_Name);
                    }
                    ViewBag.SectionName = secList;
                   
                }

                foreach (var compIdByComp in companyList)
                {
                    //Portfolio
                    foreach (var portfByComp in portfolioList)
                    {
                        SearchPortfolio search = new SearchPortfolio();

                        var tempCompQuery = portfolio_Agile_Lab_byComp.Where(x => x.Company_Id == compIdByComp.Company_Id && x.Portfolio_Id == portfByComp.Portfolio_Id).FirstOrDefault();

                        search.PortfolioId = tempCompQuery != null ? tempCompQuery.Portfolio_Id : portfByComp.Portfolio_Id;
                        search.PortfolioName = portfByComp.Portfolio_Name;
                        search.CompanyName = compIdByComp.Company_Name;
                        search.CurrentUsage = tempCompQuery.Current_Usage;
                        searchPortfolio.Add(search);
                   
                    }

                    //section
               

                    foreach (var secitem in sectionCheck)
                    {
                        var tempcompQ = homeRepo.GetAllObjectives().Where(x => x.Metadata_Id == secitem.Metadata_Id && x.Company_Id == compIdByComp.Company_Id).ToList();
                        SearchBySection SearchCompBySection = new SearchBySection();

                        double score = 0;
                        foreach (var val in tempcompQ)
                        {

                            double score_max = val.Score_Max != null ? Convert.ToDouble(val.Score_Max) : 0;
                            score = score + score_max;

                        }
                        //if (tempQ.Count > 0)
                        {
                            SearchCompBySection.CompanyName = compIdByComp.Company_Name;
                            SearchCompBySection.SectionName = secitem.Metadata_Name;
                            SearchCompBySection.Score_MAx = score;
                            searchCompBySection.Add(SearchCompBySection);
                        }
                    }
                }
                searchByComp.protfolio = searchPortfolio;
                searchByComp.section = searchCompBySection;
                return View("SearchByCompanyView", searchByComp);
            }

            if (isProfolio && !isCompany)
            {



                var portfolio_Agile_Lab = homeRepo.GetPALData();//.Where(t => companyId.Contains(t.Company_Id)).ToList();

                List<SearchPortfolio> searchPortfolio = new List<SearchPortfolio>();
                foreach (var compId in companyList)
                {

                    foreach (var portf in portfolioList)
                    {
                        SearchPortfolio search = new SearchPortfolio();

                        var tempQuery = portfolio_Agile_Lab.Where(x => x.Company_Id == compId.Company_Id && x.Portfolio_Id == portf.Portfolio_Id).FirstOrDefault();

                        search.PortfolioId = tempQuery != null ? tempQuery.Portfolio_Id : portf.Portfolio_Id;
                        search.PortfolioName = portf.Portfolio_Name;
                        search.CompanyName = compId.Company_Name;
                        search.CurrentUsage = tempQuery.Current_Usage;
                        searchPortfolio.Add(search);
                    }
                }
                //search.CompanyName = companyList.Select(x => x.Company_Name).ToList();
                //search.CompanyId = companyId;
                return View("PortfolioView", searchPortfolio);

            }
            if ((isSection || isSectionByName) && !isCompany)
            {
                List<SearchBySection> searchBySec = new List<SearchBySection>();

                var sectionList = homeRepo.GetMetadatas();
                // var objectives = db.Objectives.Include(o => o.Company).Include(o => o.Metadata).Include(o => o.Objectives1).ToList();

                if (isSectionByName)
                {
                    sectionList = homeRepo.GetMetadatas().Where(x => x.Metadata_Name.ToLower().Contains(searchKey)).ToList();

                }
                foreach (var compId in companyList)
                {

                    foreach (var secitem in sectionList)
                    {
                        var tempQ = homeRepo.GetAllObjectives().Where(x => x.Metadata_Id == secitem.Metadata_Id && x.Company_Id == compId.Company_Id).ToList();
                        SearchBySection searchbySec = new SearchBySection();

                        double score = 0;
                        foreach (var val in tempQ)
                        {

                            double score_max = val.Score_Max != null ? Convert.ToDouble(val.Score_Max) : 0;
                            score = score + score_max;

                        }
                        //if (tempQ.Count > 0)
                        {
                            searchbySec.CompanyName = compId.Company_Name;
                            searchbySec.SectionName = secitem.Metadata_Name;
                            searchbySec.Score_MAx = score;
                            searchBySec.Add(searchbySec);
                        }
                    }
                }



                return View("SearchBySectionView", searchBySec);
            }

            return View("NoResultView");
        }
    }
}