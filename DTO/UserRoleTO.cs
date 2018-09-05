using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserRoleTO
    {
        public UserRoleTO()
        {
            this.UserAccesses = new HashSet<UserAccessTO>();
        }

        public int UserRoleId { get; set; }
        public string EmailId { get; set; }
        public bool IsAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAccessTO> UserAccesses { get; set; }
    }
}
