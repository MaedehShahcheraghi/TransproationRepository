using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Responses.UserResponse
{
    public class AuthResponse
    {
        public long UserId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }

    }
}
