using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.UserEntity;

namespace TransportationSystem.Domain.Entities.UserEntities
{
    public class UserRole
    {

        public long User_Id { get; set; }
        public long Role_Id { get; set; }

        #region Relations
 
        public User user { get; set; }
        public Role Role { get; set; }

        #endregion
    }
}
