using CrossSell_App.Models;
using DataAccessLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Manager
{
    public class PortfolioTypeManager
    {
        private PortfolioTypeService repo = new PortfolioTypeService();
        public List<PortfolioTO> GetPortfolios()
        {
            var data= repo.GetPortfolios();

            var dataToReturn = data.Select(x => new PortfolioTO
            {
                Portfolio_Id = x.Portfolio_Id,
                Portfolio_Name = x.Portfolio_Name,
                Portfolio_Type_Id = x.Portfolio_Type_Id

            });
            return dataToReturn.ToList();
        }

        public PortfolioTypeTO getPortfolioTypebyId(int? id)
        {
            var x= repo.getPortfolioTypebyId(id);
          

            var result =new PortfolioTypeTO()
            {
                IsActive = x.IsActive,
                Portfolio_Type_Id = x.Portfolio_Type_Id,
                Portfolio_Type_Name = x.Portfolio_Type_Name
            };
            return result;
            
        }
        public List<PortfolioTypeTO> GetPortfolioTypes()
        {

            var data = repo.GetPortfolioTypes();

            var result = data.Select(x => new PortfolioTypeTO()
            {
                IsActive = x.IsActive,
                Portfolio_Type_Id = x.Portfolio_Type_Id,
                Portfolio_Type_Name = x.Portfolio_Type_Name
            }).ToList();
            return result;
        }
        public void savePortfolioType(PortfolioTypeTO portfoliotype)
        {
            Portfolio_Type dataToSave = new Portfolio_Type()
            {
                Portfolio_Type_Id = portfoliotype.Portfolio_Type_Id,
                Portfolio_Type_Name = portfoliotype.Portfolio_Type_Name,
                IsActive = true
            };
            repo.savePortfolioType(dataToSave);
            

            //db.Portfolio_Type.Add(dataToSave);
            //db.SaveChanges();

        }
        public void updatePortfolioType(PortfolioTypeTO portfoliotype)
        {
            Portfolio_Type dataToUpdate = new Portfolio_Type();
            dataToUpdate.Portfolio_Type_Name = portfoliotype.Portfolio_Type_Name;
            dataToUpdate.IsActive = true;
            dataToUpdate.Portfolio_Type_Id = portfoliotype.Portfolio_Type_Id;

            repo.updatePortfolioType(dataToUpdate);
            //Portfolio_Type dataToUpdate = db.Portfolio_Type.Where(x => x.Portfolio_Type_Id == portfoliotype.Portfolio_Type_Id).FirstOrDefault();
            


            //db.SaveChanges();

        }

        public void deletePortfolioTypes(int id)
        {
            repo.deletePortfolioTypes(id);
            //Portfolio_Type portfolioType = db.Portfolio_Type.Find(id);
            //portfolioType.IsActive = false;
            //try
            //{

            //    db.SaveChanges();
            //}
            //catch(Exception ex)
            //{

            //}

        }
    }
}