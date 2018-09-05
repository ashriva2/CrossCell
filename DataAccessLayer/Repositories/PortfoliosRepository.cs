using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PortfoliosRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        public List<PortfolioTO> GetPortfolios()
        {

            var data = db.Portfolios.Where(x => x.IsActive == true).ToList();

            var dataToReturn = data.Select(x => new PortfolioTO
            {
                Portfolio_Id = x.Portfolio_Id,
                Portfolio_Name = x.Portfolio_Name,
                Portfolio_Type_Id = x.Portfolio_Type_Id,
                Portfolio_Type_Name=db.Portfolio_Type.Where(c=>c.Portfolio_Type_Id==x.Portfolio_Type_Id && c.IsActive==true).Select(y=>y.Portfolio_Type_Name).FirstOrDefault()
            });
            return dataToReturn.ToList();
        }

        public PortfolioTO GetPortfoliobyId(int? id)
        {
            return db.Portfolios.Where(x => x.Portfolio_Id == id).Select(x=>
                new PortfolioTO()
                {
                    Portfolio_Id = x.Portfolio_Id,
                    Portfolio_Name = x.Portfolio_Name,
                    Portfolio_Type_Id = x.Portfolio_Type_Id,
                     Portfolio_Type_Name=x.Portfolio_Type.Portfolio_Type_Name
                   

                }).FirstOrDefault();
        }

        public void updatePortfolio(PortfolioTO portfolio)
        {
            Portfolio dataToUpdate = db.Portfolios.Where(x => x.Portfolio_Id == portfolio.Portfolio_Id).FirstOrDefault();
            dataToUpdate.Portfolio_Name = portfolio.Portfolio_Name;
           
            dataToUpdate.Portfolio_Type_Id = portfolio.Portfolio_Type_Id;
            dataToUpdate.IsActive = true;


            db.SaveChanges();

        }

        public void deletePortfolio(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            portfolio.IsActive = false;
            //db.Portfolios.Remove(portfolio);
            db.SaveChanges();
        }


        public List<PortfolioTypeTO> GetPortfolioTypes()
        {
            return db.Portfolio_Type.Where(x=>x.IsActive==true).ToList().OrderBy(x => x.Portfolio_Type_Id).Select(
                 x => new PortfolioTypeTO()
                 {
                     Portfolio_Type_Id = x.Portfolio_Type_Id,
                     Portfolio_Type_Name = x.Portfolio_Type_Name
                 }

                 ).ToList();
        }

        public void savePortfolios(PortfolioTO portfolio)
        {
            Portfolio dataToSave = new Portfolio()
            {
                Portfolio_Name = portfolio.Portfolio_Name,
                Portfolio_Type_Id = portfolio.Portfolio_Type_Id,
                IsActive = true
            };
            db.Portfolios.Add(dataToSave);
            db.SaveChanges();

        }

    }
}
