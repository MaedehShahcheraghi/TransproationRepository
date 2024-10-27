using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.UserEntities
{
    public class Role:BaseEntity
    {

        public string Role_Name { get; set; }
        public string Role_Descreption { get; set; }

        #region Relations
        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}
