using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Responses.UserResponse
{
    public class RegisterationResponse
    {
        public long UserId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ErrorMessage { get; set; } = new List<string>();
    }
}
