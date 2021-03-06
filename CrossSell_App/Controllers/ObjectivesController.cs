﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

//using CrossSell_App.DataAccess;
using CrossSell_App.Models;
using CrossSell_App.Repository;
using CrossSell_App.UtilityClasses;
using DataAccessLayer;
using DTO;

namespace CrossSell_App.Controllers
{
    public class ObjectivesController : Controller
    {
        private Utility utilObj = new Utility();
     //   private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        private ObjectivesRepository objRepo = new ObjectivesRepository();
       static UserCompaniesInfo userComapniesData;

        // GET: Objectives
        //public ActionResult Index()
        //{
        //    var objectives = db.Objectives.Include(o => o.Company).Include(o => o.Questioner).Include(o => o.Metadata).Include(o => o.Objectives1).Include(o => o.Objective1);
        //    return View(objectives.ToList());
        //}

        // GET: Objectives/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Objective objective = db.Objectives.Find(id);
        //    if (objective == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(objective);
        //}

        // GET: Objectives/Create
        public ActionResult Create(int id)
        {
            userComapniesData = utilObj.getUsercompanyInfo();
            int companyId = 0;
            if (id == 0 && userComapniesData.companyId == null)
            {
                companyId = 1;
            }
            else if(id == 0 && userComapniesData!=null && userComapniesData.companyId.Count>0)
            {
                companyId = userComapniesData.companyId.FirstOrDefault();
            }
            else
            {
                companyId = id;
            }

            ViewBag.fillCompanyddl = FillCompanyDropDown(companyId);

            

            List<ObjectiveTO> Data = new List<ObjectiveTO>();
            List<ObjectiveTO> DataList = new List<ObjectiveTO>();
            List<SectionsTO> SectionModelList = new List<SectionsTO>();
            var sectionList = objRepo.GetMetadatas().ToList();
            var ALlObjectives = objRepo.getObjectivebyCompany(companyId);
            var AllQuestioners = objRepo.getAllQuestioner();
            //Mapper.CreateMap<ALlObjectives, Data>();





            //checking if the data exists for the particular company id in db
            //Company Id is hardcoded 
            List<CompanyTO> CompanyList = new List<CompanyTO>();
            List<Int32> companyIds = new List<Int32>();
    
            
                if(userComapniesData.companyId != null)
                {
                companyIds = userComapniesData.companyId;
            }
                else
             {
                
                companyIds.Add(companyId);
            }
        
           
              var companyData = ALlObjectives.Where(x => x.Company_Id == companyId).OrderBy(x => x.Objective_Id).ToList();



            if (companyData.Count == 0)
            {
                foreach (var sect in sectionList)
                {
                    SectionsTO obj = new SectionsTO()
                    {
                        Metadata_Id = sect.Metadata_Id,
                        Metadata_Name = sect.Metadata_Name,
                        IsActive = sect.IsActive
                    };
                    SectionModelList.Add(obj);



                }

                ViewBag.SectionList = SectionModelList;

                foreach (var item in sectionList)
                {
                    try
                    {


                        //DataList.Add(DataInput);
                        var getQuesForMeta = AllQuestioners.Where(x => x.Metadata_Id == item.Metadata_Id).ToList();
                        foreach (var ques in getQuesForMeta)
                        {
                            ObjectiveTO DataInput = new ObjectiveTO();
                            DataInput.MetaDataText = item.Metadata_Name;

                            DataInput.QuestionText = ques.Questioner1;
                            DataInput.Questioner_Id = ques.Questioner_Id;
                            DataInput.Metadata_Id = item.Metadata_Id;
                            DataList.Add(DataInput);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            else
            {
                foreach (var sect in sectionList)
                {
                    SectionsTO obj = new SectionsTO()
                    {
                        Metadata_Id = sect.Metadata_Id,
                        Metadata_Name = sect.Metadata_Name,
                        IsActive = sect.IsActive
                    };
                    SectionModelList.Add(obj);



                }

                ViewBag.SectionList = SectionModelList;

                foreach (var item in sectionList)
                {
                    try
                    {


                        //DataList.Add(DataInput);
                        var getQuesForMeta =AllQuestioners.Where(x => x.Metadata_Id == item.Metadata_Id).ToList();
                        foreach (var ques in getQuesForMeta)
                        {
                            var dataExist = ALlObjectives.Where(x => x.Metadata_Id == ques.Metadata_Id && x.Questioner_Id == ques.Questioner_Id && x.Company_Id == companyId).FirstOrDefault();
                            if (dataExist != null)
                            {
                                ObjectiveTO DataInput = new ObjectiveTO();
                                DataInput.MetaDataText = item.Metadata_Name;

                                DataInput.QuestionText = ques.Questioner1;
                                DataInput.Questioner_Id = ques.Questioner_Id;
                                DataInput.Metadata_Id = item.Metadata_Id;
                                DataInput.Level = dataExist.Level;
                                DataInput.Weight = dataExist.Weight;
                                DataInput.Answer = dataExist.Answer;
                                DataInput.Score = dataExist.Score;
                                DataInput.Score_Max = dataExist.Score_Max;
                                DataInput.Max = dataExist.Max;
                                DataInput.Comments = dataExist.Comments;
                                DataList.Add(DataInput);
                            }
                            else
                            {
                                ObjectiveTO DataInput = new ObjectiveTO();
                                DataInput.MetaDataText = item.Metadata_Name;

                                DataInput.QuestionText = ques.Questioner1;
                                DataInput.Questioner_Id = ques.Questioner_Id;
                                DataInput.Metadata_Id = item.Metadata_Id;
                                DataList.Add(DataInput);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }


            }

            return View(DataList);
        }

        // POST: Objectives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateData(List<ObjectiveTO> jsonObj)
        {

            string message;
            var ObjectivesbyId = objRepo.getObjectivebyCompany(jsonObj[0].Company_Id);

            foreach (var item in jsonObj)
            {

                try
                {

                    var dataExist = ObjectivesbyId.Where(x=>x.Metadata_Id == item.Metadata_Id && x.Questioner_Id==item.Questioner_Id).FirstOrDefault();
                    if (dataExist == null)
                    {
                        ObjectiveTO saveData = new ObjectiveTO()
                        {
                            Company_Id = item.Company_Id,
                            Metadata_Id = item.Metadata_Id,
                            Questioner_Id = item.Questioner_Id,
                            Comments = item.Comments,
                            Level = item.Level,
                            Score = item.Score,
                            Score_Max = item.Score_Max,
                            Max = item.Max,
                            Weight = item.Weight,
                            Answer = item.Answer



                        };

                        objRepo.SaveObjective(saveData);
                    }

                    else
                    {

                        //dataExist.Company_Id = 3;
                        //dataExist.Metadata_Id = item.Metadata_Id;
                        //dataExist.Questioner_Id = item.Questioner_Id;
                        dataExist.Comments = item.Comments;
                        dataExist.Level = item.Level;
                        dataExist.Score = item.Score;
                        dataExist.Score_Max = item.Score_Max;
                        dataExist.Max = item.Max;
                        dataExist.Weight = item.Weight;
                        dataExist.Answer = item.Answer;


                        objRepo.UpdateObjective(dataExist);

                       



                    }
                }

                catch (Exception e)
                {
                    message = "Some thing went wrong . Please contact IT team ";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
            }
            message = "Date saved successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
            //ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name", objective.Company_Id);
            //ViewBag.Questioner_Id = new SelectList(db.Questioners, "Questioner_Id", "Questioner1", objective.Questioner_Id);
            //ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name", objective.Metadata_Id);
            //ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
            //ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);

        }

        // GET: Objectives/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Objective objective = db.Objectives.Find(id);
        //    if (objective == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name", objective.Company_Id);
        //    ViewBag.Questioner_Id = new SelectList(db.Questioners, "Questioner_Id", "Questioner1", objective.Questioner_Id);
        //    ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name", objective.Metadata_Id);
        //    ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
        //    ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
        //    return View(objective);
        //}

        // POST: Objectives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public ActionResult Edit([Bind(Include = "Objective_Id,Comments,Weight,Score_Max,Max,Answer,Score,Level,Metadata_Id,IsActive,Questioner_Id,Company_Id")] Objective objective)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(objective).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name", objective.Company_Id);
        //    ViewBag.Questioner_Id = new SelectList(db.Questioners, "Questioner_Id", "Questioner1", objective.Questioner_Id);
        //    ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name", objective.Metadata_Id);
        //    ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
        //    ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
        //    return View(objective);
        //}

        // GET: Objectives/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Objective objective = db.Objectives.Find(id);
        //    if (objective == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(objective);
        //}

        //// POST: Objectives/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Objective objective = db.Objectives.Find(id);
        //    db.Objectives.Remove(objective);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private List<SelectListItem> FillCompanyDropDown(int val)
        {

            List<SelectListItem> listItems = new List<SelectListItem>();
            //var companyList = db.Companies.ToList();
            List<CompanyTO> companyList = new List<CompanyTO>();
            List<Int32> companyIds = new List<Int32>();
            
            if (userComapniesData.companyId == null)
            {

                companyList = objRepo.GetCompanies().ToList();
            }
            else
            {
                companyList = userComapniesData.comPanies;
            }
            foreach (var item in companyList)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Company_Name,
                    Value = Convert.ToString(item.Company_Id),
                    Selected = val == item.Company_Id ? true : false
                });
            }

            return listItems;
        }
    }
}
