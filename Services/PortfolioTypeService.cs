
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repositories;
namespace Services
{
    public class PortfolioTypeService
    {
        private PortfolioTypeRepository repo = new PortfolioTypeRepository();
        public List<Portfolio> GetPortfolios()
        {
            return repo.GetPortfolios();

            //var dataToReturn = data.Select(x => new PortfolioTO
            //{
            //    Portfolio_Id = x.Portfolio_Id,
            //    Portfolio_Name = x.Portfolio_Name,
            //    Portfolio_Type_Id = x.Portfolio_Type_Id

            //});
            //return dataToReturn.ToList();
        }

        public Portfolio_Type getPortfolioTypebyId(int? id)
        {
            return repo.getPortfolioTypebyId(id);
            //return db.Portfolio_Type.Where(x => x.Portfolio_Type_Id == id).Select(
            //    x=> new PortfolioTypeTO()
            //    {
            //         Portfolio_Type_Id=x.Portfolio_Type_Id,
            //           Portfolio_Type_Name=x.Portfolio_Type_Name
            //    }
                
            //    ).FirstOrDefault();
        }
        public List<Portfolio_Type> GetPortfolioTypes()
        {

            return repo.GetPortfolioTypes();
            //return db.Portfolio_Type.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Portfolio_Type_Id).Select(
            //    x => new PortfolioTypeTO()
            //    {
            //        Portfolio_Type_Id = x.Portfolio_Type_Id,
            //        Portfolio_Type_Name = x.Portfolio_Type_Name
            //    }

            //    ). ToList();
        }
        public void savePortfolioType(Portfolio_Type portfoliotype)
        {
            repo.savePortfolioType(portfoliotype);
            //Portfolio_Type dataToSave = new Portfolio_Type()
            //{
            //    Portfolio_Type_Id = portfoliotype.Portfolio_Type_Id,
            //    Portfolio_Type_Name = portfoliotype.Portfolio_Type_Name,
            //    IsActive = true
            //};

            //db.Portfolio_Type.Add(dataToSave);
            //db.SaveChanges();

        }
        public void updatePortfolioType(Portfolio_Type portfoliotype)
        {
            repo.updatePortfolioType(portfoliotype);
            //Portfolio_Type dataToUpdate = db.Portfolio_Type.Where(x => x.Portfolio_Type_Id == portfoliotype.Portfolio_Type_Id).FirstOrDefault();
            //dataToUpdate.Portfolio_Type_Name = portfoliotype.Portfolio_Type_Name;
            //dataToUpdate.IsActive = portfoliotype.IsActive;
          


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
