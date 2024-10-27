using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Domain.Entities.UserEntities
{
    public class RolePermission
    {
        public long Role_Id { get; set; }
        public long Permission_Id { get; set; }

        #region Relations

     
        public Role Role { get; set; }
        public Permission Permission { get; set; }

        #endregion
    }
}
