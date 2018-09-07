
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace Services
{
    public class PortfoliosService
    {
        private PortfoliosRepository repo = new PortfoliosRepository();
        public List<Portfolio> GetPortfolios()
        {

           return repo.GetPortfolios();

            //var dataToReturn = data.Select(x => new PortfolioTO
            //{
            //    Portfolio_Id = x.Portfolio_Id,
            //    Portfolio_Name = x.Portfolio_Name,
            //    Portfolio_Type_Id = x.Portfolio_Type_Id,
            //    Portfolio_Type_Name=db.Portfolio_Type.Where(c=>c.Portfolio_Type_Id==x.Portfolio_Type_Id && c.IsActive==true).Select(y=>y.Portfolio_Type_Name).FirstOrDefault()
            //});
            //return dataToReturn.ToList();
        }

        public Portfolio GetPortfoliobyId(int? id)
        {
            return repo.GetPortfoliobyId(id);
            //return db.Portfolios.Where(x => x.Portfolio_Id == id).Select(x=>
            //    new PortfolioTO()
            //    {
            //        Portfolio_Id = x.Portfolio_Id,
            //        Portfolio_Name = x.Portfolio_Name,
            //        Portfolio_Type_Id = x.Portfolio_Type_Id,
            //         Portfolio_Type_Name=x.Portfolio_Type.Portfolio_Type_Name


            //    }).FirstOrDefault();
        }

        public void updatePortfolio(Portfolio portfolio)
        {
            repo.updatePortfolio(portfolio);
            //Portfolio dataToUpdate = db.Portfolios.Where(x => x.Portfolio_Id == portfolio.Portfolio_Id).FirstOrDefault();
            //dataToUpdate.Portfolio_Name = portfolio.Portfolio_Name;
           
            //dataToUpdate.Portfolio_Type_Id = portfolio.Portfolio_Type_Id;
            //dataToUpdate.IsActive = true;


            //db.SaveChanges();

        }

        public void deletePortfolio(int id)
        {
            repo.deletePortfolio(id);
        }


        public List<Portfolio_Type> GetPortfolioTypes()
        {
            return repo.GetPortfolioTypes();
        }

        public void savePortfolios(Portfolio portfolio)
        {
            repo.savePortfolios(portfolio);

        }

    }
}
