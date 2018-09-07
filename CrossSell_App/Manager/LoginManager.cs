using CrossSell_App.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Manager
{
    public class LoginManager
    {
        private LoginService repo = new LoginService();

        public List<UserAccessTO> GetAllUsers()
        {
            var data = repo.GetAllUsers();

            var result = data.Select(x => new UserAccessTO()
            {

                CompanyId=x.CompanyId,
                 UserRoleId=x.UserRoleId,
                 UserAccessId=x.UserAccessId
               

            }).ToList();
            return result;
        }

        public List<UserAccessTO> GetUsersCompany(int UserRoleId)
        {
            var data= repo.GetUsersCompany(UserRoleId);
            var result = data.Select(x => new UserAccessTO()
            {
                CompanyId = x.CompanyId,
                UserRoleId = x.UserRoleId,
                UserAccessId = x.UserAccessId
            }).ToList();
            return result;
        }
        public UserRoleTO GetUser(string emailId)
        {
            var data= repo.GetUser(emailId);
            UserRoleTO result = new UserRoleTO()
            {
                UserRoleId = data.UserRoleId,
                EmailId = data.EmailId,
                IsAdmin = data.IsAdmin,

            };
            return result;
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