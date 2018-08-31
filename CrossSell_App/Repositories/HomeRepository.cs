
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CrossSell_App.Repositories
{
    public class HomeRepository
    {

        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        public List<Portfolio_Agile_Lab> GetPALData()
        {
            return db.Portfolio_Agile_Lab.ToList().OrderBy(x => x.Portfolio_Id).ToList();
        }

        public List<Portfolio> GetPortfolios()
        {
            return db.Portfolios.ToList().OrderBy(x => x.Portfolio_Id).ToList();
        }

        public List<Company> GetCompanies()
        {
            return db.Companies.ToList().OrderBy(x => x.Company_Id).ToList();
        }


        public List<Metadata> GetMetadatas()
        {
            return db.Metadatas.ToList().Where(x => x.Metadata_Id != 7).OrderBy(x => x.Metadata_Id).ToList();
        }
        public List<Objective> GetAllObjectives()
        {
            return db.Objectives.OrderBy(x => x.Objective_Id).ToList();
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