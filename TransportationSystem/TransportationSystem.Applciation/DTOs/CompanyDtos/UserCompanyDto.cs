using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.CompanyDtos
{
    public class UserCompanyDto
    {
        public long CompanyId { get; set; }
        public List<long> UsersId  { get; set; }
    }
}
