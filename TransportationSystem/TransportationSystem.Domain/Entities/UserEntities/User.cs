using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;
using TransportationSystem.Domain.Entities.UserEntities;

namespace TransportationSystem.Domain.Entities.UserEntity
{
    public class User:BaseEntity
    {

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AcivationEmail { get; set; }
        public string Phone { get; set; }
        public string AcivationPhone { get; set; }
        public bool IsActive { get; set; }
        public string? UserAvatar { get; set; }
        public string? National_Code { get; set; }

        #region Relations
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }

        #endregion
    }
}
