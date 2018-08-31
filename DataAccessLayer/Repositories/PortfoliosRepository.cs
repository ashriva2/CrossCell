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
        public List<Portfolio> GetPortfolios()
        {
            return db.Portfolios.ToList().OrderBy(x => x.Portfolio_Id).ToList();
        }

        public Portfolio GetPortfoliobyId(int? id)
        {
            return db.Portfolios.Where(x=>x.Portfolio_Id==id).FirstOrDefault();
        }

        public void updatePortfolio(Portfolio portfolio)
        {
            Portfolio dataToUpdate = db.Portfolios.Where(x => x.Portfolio_Id == portfolio.Portfolio_Id).FirstOrDefault();
            dataToUpdate.Portfolio_Name = portfolio.Portfolio_Name;
            dataToUpdate.Portfolio_Type = portfolio.Portfolio_Type;
            dataToUpdate.Portfolio_Type_Id = portfolio.Portfolio_Type_Id;


            db.SaveChanges();

        }

        public void deletePortfolio(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(portfolio);
            db.SaveChanges();
        }


        public List<Portfolio_Type> GetPortfolioTypes()
        {
            return db.Portfolio_Type.ToList().OrderBy(x => x.Portfolio_Type_Id).ToList();
        }

        public void  savePortfolios(Portfolio portfolio)
        {
            db.Portfolios.Add(portfolio);
            db.SaveChanges();
       
        }

    }
}
