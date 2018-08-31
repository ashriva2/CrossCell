
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DataAccessLayer;

namespace CrossSell_App.Repository
{
    public class PortfolioAgileLabRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        public IQueryable<Portfolio_Agile_Lab> GetAllPAL()
        {
            return db.Portfolio_Agile_Lab.Include(p => p.Company).Include(p => p.Portfolio);          
        }

        public List<Portfolio_Agile_Lab> GetPALByCompanyId(int? id)
        {
            return db.Portfolio_Agile_Lab.Where(x => x.Company_Id == id).ToList();
        }

        public List<Portfolio_Type> GetAllPortfolioType()
        {
            return db.Portfolio_Type.OrderBy(x=>x.Portfolio_Type_Id).ToList();
        }

        public List<Portfolio> GetAllPortfolio()
        {
            return db.Portfolios.OrderBy(x=>x.Portfolio_Id).ToList();
        }

        public List<Company> GetAllCompanies()
        {
            return db.Companies.OrderBy(t=>t.Company_Id).ToList();
        }


        public Portfolio_Agile_Lab getPalbyId(int? id)
        {
            return db.Portfolio_Agile_Lab.Find(id);
        }

        public  void DeletePAL(int? id)
        {
            Portfolio_Agile_Lab portfolio_Agile_Lab = getPalbyId(id);
            db.Portfolio_Agile_Lab.Remove(portfolio_Agile_Lab);
            db.SaveChanges();
        }



        public void Update_Portfolio_Agile_LabData(int PortfolioId, string Curr_Usg, bool FutrFcsd, bool IsMrktLd, int CompanyId)
        {
            Portfolio_Agile_Lab portfolio_Agile_Lab = db.Portfolio_Agile_Lab.Where(x => x.Company_Id == CompanyId && x.Portfolio_Id == PortfolioId).FirstOrDefault();

            portfolio_Agile_Lab.Current_Usage = Convert.ToInt16(Curr_Usg);
            portfolio_Agile_Lab.Future_Scope = FutrFcsd;
            portfolio_Agile_Lab.IsMarketLead = IsMrktLd;


            db.SaveChanges();
        }


        public void savePALData(Portfolio_Agile_Lab dataTOsave)
        {

        }


        
        public bool CheckIfPortfolio_CompanyExist(int Portfolio_Id, int Company_Id)
        {
            var Data = db.Portfolio_Agile_Lab.Where(x => x.Portfolio_Id == Portfolio_Id && x.Company_Id == Company_Id).Select(x => x.Company_Id);
            if (Data.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)

            {

                if (disposing)

                {

                    db.Dispose();

                }

            }

            this.disposed = true;
        }
        public void Dispose()

        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }
    }
}