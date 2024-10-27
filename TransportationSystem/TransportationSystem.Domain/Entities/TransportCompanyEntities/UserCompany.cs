using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.UserEntity;

namespace TransportationSystem.Domain.Entities.TransportCompanyEntities
{
    public class UserCompany
    {
        public long UserId { get; set; }
        public long CompanyId { get; set; }

        #region Relations
        public User User { get; set; }
        public TransportCompany TransportCompany { get; set; }
        #endregion
    }
}
