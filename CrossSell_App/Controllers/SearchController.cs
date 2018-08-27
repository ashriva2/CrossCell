﻿using CrossSell_App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Net;
using CrossSell_App.Models;

namespace CrossSell_App.Controllers
{
    public class SearchController : Controller
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        // GET: Search
        public ActionResult SearchAlgorithm(string searchKey)
        {
            ViewBag.SearchText = searchKey;
            bool isProfolio = false;
            bool isSection = false;
            bool isSectionByName = false;
            //Get the user from UserRole table
            //Get the useraccess from UserAccess table
            List<int> companyId = new List<int>();
            companyId.Add(1);
            companyId.Add(2);
            companyId.Add(3);

            companyId.Sort();
            var companyList = db.Companies.Where(c => companyId.Contains(c.Company_Id)).Select(x => new { x.Company_Name, x.Company_Id }).OrderBy(x => x.Company_Id).ToList();
            List<string> cList = new List<string>();
            foreach (var c in companyList)
            {
                cList.Add(c.Company_Name);
            }
            ViewBag.CompanyList = cList;
            //Portfolio portfolio = db.Portfolios.Find(id);

            var portfolioList = db.Portfolios.ToList();

            if ("portfolio".Contains(searchKey.ToLower()))
            {
                isProfolio = true;
                ViewBag.PortFolioList = portfolioList;

            }
             if (!isProfolio)
            {
                var portFolioCheck = portfolioList.Where(x => x.Portfolio_Name.ToLower().Contains(searchKey.ToLower())).ToList();
                if (portFolioCheck.Count > 0)
                {
                    isProfolio = true;
                    portfolioList = portFolioCheck;
                    ViewBag.PortFolioList = portfolioList;

                }
            }
             if(!isProfolio)
            {
                if (searchKey.ToLower().Contains("section"))
                {
                    var sectionCheck = db.Metadatas.ToList();
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
                else if(!isSection)
                {
                    var sectionCheck = db.Metadatas.Where(x => x.Metadata_Name.ToLower().Contains(searchKey.ToLower())).ToList();
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


            if (isProfolio)
            {



                var portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Include(p => p.Company).Include(p => p.Portfolio).ToList();//.Where(t => companyId.Contains(t.Company_Id)).ToList();

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
            if (isSectionByName)
            {

            }
            if (isSection || isSectionByName)
            {
                List<SearchBySection> searchBySec = new List<SearchBySection>();

                var sectionList = db.Metadatas.ToList();
                // var objectives = db.Objectives.Include(o => o.Company).Include(o => o.Metadata).Include(o => o.Objectives1).ToList();

                if (isSectionByName)
                {
                     sectionList = db.Metadatas.Where(x=>x.Metadata_Name.ToLower().Contains(searchKey)).ToList();

                }
                foreach (var compId in companyList)
                {

                    foreach (var secitem in sectionList)
                    {
                        var tempQ = db.Objectives.Where(x => x.Metadata_Id == secitem.Metadata_Id && x.Company_Id == compId.Company_Id).ToList();
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

            return View("PortfolioView");
        }
    }
}