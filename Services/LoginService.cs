
using DataAccessLayer;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
    public class LoginService
    {
        private LoginRepository repo = new LoginRepository();

        public List<UserAccess> GetAllUsers()
        {
            return repo.GetAllUsers();
        }

        public List<UserAccess> GetUsersCompany(int UserRoleId)
        {
            return repo.GetUsersCompany(UserRoleId);
        }
        public UserRole GetUser(string emailId)
        {
            return repo.GetUser(emailId);
        }
        private bool disposed = false;
        //public void Dispose(bool disposing)
        //{
        //    if (!this.disposed)

        //    {

        //        if (disposing)

        //        {

        //            db.Dispose();

        //        }

        //    }

        //    this.disposed = true;
        //}
        //public void Dispose()

        //{

        //    Dispose(true);

        //    GC.SuppressFinalize(this);

        //}


    }
}