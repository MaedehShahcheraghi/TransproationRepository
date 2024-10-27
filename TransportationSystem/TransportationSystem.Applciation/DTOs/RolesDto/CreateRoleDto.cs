using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.RolesDto
{
    public class CreateRoleDto:IRoleDto
    {
        public string Role_Name { get; set; }
        public string Role_Descreption { get; set; }
    }
}
