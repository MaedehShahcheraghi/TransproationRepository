using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Models.User_Model
{
    public class RegisterationRequest
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
