using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PortfolioTypeRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        public List<Portfolio> GetPortfolios()
        {
            return db.Portfolios.ToList().OrderBy(x => x.Portfolio_Id).ToList();
        }

        public Portfolio_Type getPortfolioTypebyId(int? id)
        {
            return db.Portfolio_Type.Where(x => x.Portfolio_Type_Id == id).FirstOrDefault();
        }
        public List<Portfolio_Type> GetPortfolioTypes()
        {
            return db.Portfolio_Type.ToList().OrderBy(x => x.Portfolio_Type_Id).ToList();
        }
        public void savePortfolioType(Portfolio_Type portfoliotype)
        {
            db.Portfolio_Type.Add(portfoliotype);
            db.SaveChanges();

        }
        public void updatePortfolioType(Portfolio_Type portfoliotype)
        {
            Portfolio_Type dataToUpdate = db.Portfolio_Type.Where(x => x.Portfolio_Type_Id == portfoliotype.Portfolio_Type_Id).FirstOrDefault();
            dataToUpdate.Portfolio_Type_Name = portfoliotype.Portfolio_Type_Name;
          


            db.SaveChanges();

        }

        public void deletePortfolioTypes(int id)
        {
            Portfolio_Type portfolioType = db.Portfolio_Type.Find(id);
            try
            {
                db.Portfolio_Type.Remove(portfolioType);
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
       
        }
    }
}
