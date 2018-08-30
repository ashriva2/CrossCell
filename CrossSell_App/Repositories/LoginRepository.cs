using CrossSell_App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Repository
{
    public class LoginRepository:IDisposable
    {
        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();

        public List<UserAccess> GetAllUsers()
        {
            return db.UserAccesses.ToList();
        }

        public List<UserAccess> GetUsersCompany(int UserRoleId)
        {
            return db.UserAccesses.Where(x=>x.UserRoleId==UserRoleId).ToList();
        }
        public UserRole GetUser(string emailId)
        {
            return db.UserRoles.Where(x=>x.EmailId==emailId).FirstOrDefault();
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