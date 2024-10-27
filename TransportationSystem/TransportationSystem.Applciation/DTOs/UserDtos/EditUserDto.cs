using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.Common;

namespace TransportationSystem.Applciation.DTOs.UserDtos
{
    public class EditUserDto:BaseDto,IUserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? National_Code { get; set; }
        public string Phone { get; set; }
    }
}
