using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.TransportCompanyEntities
{
    public class TransportCompany:BaseEntity
    {
        public int Company_Code { get; set; }
        public string Company_Name { get; set; }
        public string RegisterationNumber { get; set; }
        public string Address { get; set; }

        #region Realations
        public ICollection<UserCompany> UserCompanies { get; set; }
        #endregion
    }
}
