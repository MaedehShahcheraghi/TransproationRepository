using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.UserDtos
{
    public class UserRoleDto
    {
        public long User_Id { get; set; }
        public List<int> roleIds { get; set; }
    }
}
