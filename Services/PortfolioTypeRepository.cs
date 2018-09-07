using DTO;
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
        public List<PortfolioTO> GetPortfolios()
        {
            var data = db.Portfolios.Where(x=>x.IsActive==true).ToList();

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
            return db.Portfolio_Type.Where(x => x.Portfolio_Type_Id == id).Select(
                x=> new PortfolioTypeTO()
                {
                     Portfolio_Type_Id=x.Portfolio_Type_Id,
                       Portfolio_Type_Name=x.Portfolio_Type_Name
                }
                
                ).FirstOrDefault();
        }
        public List<PortfolioTypeTO> GetPortfolioTypes()
        {
            return db.Portfolio_Type.Where(x => x.IsActive == true).ToList().OrderBy(x => x.Portfolio_Type_Id).Select(
                x => new PortfolioTypeTO()
                {
                    Portfolio_Type_Id = x.Portfolio_Type_Id,
                    Portfolio_Type_Name = x.Portfolio_Type_Name
                }

                ). ToList();
        }
        public void savePortfolioType(PortfolioTypeTO portfoliotype)
        {
            Portfolio_Type dataToSave = new Portfolio_Type()
            {
                Portfolio_Type_Id = portfoliotype.Portfolio_Type_Id,
                Portfolio_Type_Name = portfoliotype.Portfolio_Type_Name,
                IsActive = true
            };

            db.Portfolio_Type.Add(dataToSave);
            db.SaveChanges();

        }
        public void updatePortfolioType(PortfolioTypeTO portfoliotype)
        {
            Portfolio_Type dataToUpdate = db.Portfolio_Type.Where(x => x.Portfolio_Type_Id == portfoliotype.Portfolio_Type_Id).FirstOrDefault();
            dataToUpdate.Portfolio_Type_Name = portfoliotype.Portfolio_Type_Name;
            dataToUpdate.IsActive = portfoliotype.IsActive;
          


            db.SaveChanges();

        }

        public void deletePortfolioTypes(int id)
        {
            Portfolio_Type portfolioType = db.Portfolio_Type.Find(id);
            portfolioType.IsActive = false;
            try
            {
               
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
       
        }
    }
}
