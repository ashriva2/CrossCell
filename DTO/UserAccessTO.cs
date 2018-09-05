using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserAccessTO
    {
        public int UserAccessId { get; set; }
        public int UserRoleId { get; set; }
        public int CompanyId { get; set; }

        public virtual CompanyTO Company { get; set; }
        public virtual UserRoleTO UserRole { get; set; }
    }
}
    