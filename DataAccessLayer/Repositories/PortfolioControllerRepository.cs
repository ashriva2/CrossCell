using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Repository
{
    public class PortfolioControllerRepository
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
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