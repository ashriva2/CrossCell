using CrossSell_App.Models;
using DataAccessLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Manager
{
    public class PortfolioManager
    {
        private PortfoliosService repo = new PortfoliosService();
        public List<PortfolioTO> GetPortfolios()
        {

            var data= repo.GetPortfolios();

            var dataToReturn = data.Select(x => new PortfolioTO
            {
                Portfolio_Id = x.Portfolio_Id,
                Portfolio_Name = x.Portfolio_Name,
                Portfolio_Type_Id = x.Portfolio_Type_Id,
                Portfolio_Type_Name = GetPortfolioTypes().Where(c => c.Portfolio_Type_Id == x.Portfolio_Type_Id && c.IsActive == true).Select(y => y.Portfolio_Type_Name).FirstOrDefault()
            });
            return dataToReturn.ToList();
        }

        public PortfolioTO GetPortfoliobyId(int? id)
        {
            var x= repo.GetPortfoliobyId(id);
            PortfolioTO result = new PortfolioTO()
            {
                Portfolio_Id = x.Portfolio_Id,
                Portfolio_Name = x.Portfolio_Name,
                Portfolio_Type_Id = x.Portfolio_Type_Id,
                Portfolio_Type_Name = x.Portfolio_Type.Portfolio_Type_Name


            };
            return result;
        }

        public void updatePortfolio(PortfolioTO portfolio)
        {
            Portfolio dataToUpdate = new Portfolio();
            dataToUpdate.Portfolio_Name = portfolio.Portfolio_Name;
            dataToUpdate.Portfolio_Id = portfolio.Portfolio_Id;
            dataToUpdate.Portfolio_Type_Id = portfolio.Portfolio_Type_Id;
            dataToUpdate.IsActive = true;
            repo.updatePortfolio(dataToUpdate);

          

        }

        public void deletePortfolio(int id)
        {
            repo.deletePortfolio(id);
        }


        public List<PortfolioTypeTO> GetPortfolioTypes()
        {
            var data= repo.GetPortfolioTypes();

            var result = data.Select(x => new PortfolioTypeTO()
            {
                IsActive = x.IsActive,
                Portfolio_Type_Id = x.Portfolio_Type_Id,
                Portfolio_Type_Name = x.Portfolio_Type_Name
            }).ToList();
            return result;
        }

        public void savePortfolios(PortfolioTO portfolio)
        {
            Portfolio dataToSave = new Portfolio()
            {
                IsActive = portfolio.IsActive,
                Portfolio_Type_Id = portfolio.Portfolio_Type_Id,
                Portfolio_Id = portfolio.Portfolio_Id,
                Portfolio_Name = portfolio.Portfolio_Name


            };

            repo.savePortfolios(dataToSave);

        }
    }
}