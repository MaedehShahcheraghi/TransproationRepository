using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.UserEntities
{
    public class Permission:BaseEntity
    {
        public string Permission_Name { get; set; }
        public long? Parent_Permission_Id { get; set; }

        #region Relations
        [ForeignKey("Parent_Permission_Id")]
        public List<Permission> Permissions { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }

      

        #endregion
    }
}
