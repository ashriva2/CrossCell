using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrossSell_App.DataAccess;
using CrossSell_App.Models;

namespace CrossSell_App.Controllers
{
    public class ObjectivesController : Controller
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        // GET: Objectives
        public ActionResult Index()
        {
            var objectives = db.Objectives.Include(o => o.Company).Include(o => o.Questioner).Include(o => o.Metadata).Include(o => o.Objectives1).Include(o => o.Objective1);
            return View(objectives.ToList());
        }

        // GET: Objectives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objective objective = db.Objectives.Find(id);
            if (objective == null)
            {
                return HttpNotFound();
            }
            return View(objective);
        }

        // GET: Objectives/Create
        public ActionResult Create()
        {



            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name");
            ViewBag.Questioner_Id = new SelectList(db.Questioners, "Questioner_Id", "Questioner1");
            ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name");
            ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments");
            ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments");

            ObjectivesModel Data = new ObjectivesModel();
            List<ObjectivesModel> DataList =new List<ObjectivesModel>();
            List<SectionModel> SectionModelList = new List<SectionModel>();
            var sectionList = db.Metadatas.ToList();
            //checking if the data exists for the particular company id in db
            //Company Id is hardcoded 
            var companyData = db.Objectives.Where(x => x.Company_Id == 1).OrderBy(x=>x.Objective_Id).ToList();

            if (companyData.Count == 0)
            {
                foreach (var sect in sectionList)
                {
                    SectionModel obj = new SectionModel()
                    {
                        Metadata_Id = sect.Metadata_Id,
                        Metadata_Name = sect.Metadata_Name,
                        IsActive = sect.IsActive
                    };
                    SectionModelList.Add(obj);



                }

                ViewBag.SectionList = SectionModelList;

                foreach (var item in db.Metadatas.ToList())
                {
                    try
                    {


                        //DataList.Add(DataInput);
                        var getQuesForMeta = db.Questioners.Where(x => x.Metadata_Id == item.Metadata_Id).ToList();
                        foreach (var ques in getQuesForMeta)
                        {
                            ObjectivesModel DataInput = new ObjectivesModel();
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
                    SectionModel obj = new SectionModel()
                    {
                        Metadata_Id = sect.Metadata_Id,
                        Metadata_Name = sect.Metadata_Name,
                        IsActive = sect.IsActive
                    };
                    SectionModelList.Add(obj);



                }

                ViewBag.SectionList = SectionModelList;

                foreach (var item in db.Metadatas.ToList())
                {
                    try
                    {


                        //DataList.Add(DataInput);
                        var getQuesForMeta = db.Questioners.Where(x => x.Metadata_Id == item.Metadata_Id).ToList();
                        foreach (var ques in getQuesForMeta)
                        {
                            var dataExist = db.Objectives.Where(x => x.Metadata_Id == ques.Metadata_Id && x.Questioner_Id == ques.Questioner_Id).FirstOrDefault();
                            if (dataExist != null)
                            {
                                ObjectivesModel DataInput = new ObjectivesModel();
                                DataInput.MetaDataText = item.Metadata_Name;

                                DataInput.QuestionText = ques.Questioner1;
                                DataInput.Questioner_Id = ques.Questioner_Id;
                                DataInput.Metadata_Id = item.Metadata_Id;
                                DataInput.Level = dataExist.Level;
                                DataInput.Weight = dataExist.Weight ;
                                DataInput.Answer = dataExist.Answer;
                                DataInput.Score = dataExist.Score;
                                DataInput.Score_Max = dataExist.Score_Max;
                                DataInput.Max = dataExist.Max;
                                DataInput.Comments = dataExist.Comments;
                                DataList.Add(DataInput);
                            }
                            else
                            {
                                ObjectivesModel DataInput = new ObjectivesModel();
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
        public ActionResult CreateData(List<ObjectivesModel> jsonObj)
        {

            string message;
            
            foreach(var item in jsonObj)
            {

                try
                {

                    var dataExist = db.Objectives.Where(x => x.Company_Id == item.Company_Id && x.Metadata_Id == item.Metadata_Id).FirstOrDefault();
                    if (dataExist == null)
                    {
                        Objective saveData = new Objective()
                        {
                            Company_Id = 3,
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


                        db.Objectives.Add(saveData);
                        db.SaveChanges();

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

                        db.SaveChanges();



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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objective objective = db.Objectives.Find(id);
            if (objective == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name", objective.Company_Id);
            ViewBag.Questioner_Id = new SelectList(db.Questioners, "Questioner_Id", "Questioner1", objective.Questioner_Id);
            ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name", objective.Metadata_Id);
            ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
            ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
            return View(objective);
        }

        // POST: Objectives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Objective_Id,Comments,Weight,Score_Max,Max,Answer,Score,Level,Metadata_Id,IsActive,Questioner_Id,Company_Id")] Objective objective)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objective).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Company_Name", objective.Company_Id);
            ViewBag.Questioner_Id = new SelectList(db.Questioners, "Questioner_Id", "Questioner1", objective.Questioner_Id);
            ViewBag.Metadata_Id = new SelectList(db.Metadatas, "Metadata_Id", "Metadata_Name", objective.Metadata_Id);
            ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
            ViewBag.Objective_Id = new SelectList(db.Objectives, "Objective_Id", "Comments", objective.Objective_Id);
            return View(objective);
        }

        // GET: Objectives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objective objective = db.Objectives.Find(id);
            if (objective == null)
            {
                return HttpNotFound();
            }
            return View(objective);
        }

        // POST: Objectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objective objective = db.Objectives.Find(id);
            db.Objectives.Remove(objective);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
