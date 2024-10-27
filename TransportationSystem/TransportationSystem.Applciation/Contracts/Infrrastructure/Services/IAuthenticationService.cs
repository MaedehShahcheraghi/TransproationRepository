using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Models.User_Model;
using TransportationSystem.Applciation.Responses.UserResponse;

namespace TransportationSystem.Applciation.Contracts.Infrrastructure.Services
{
    public interface IAuthenticationService
    {

        Task<AuthResponse> Login(AuthRequest request);
        Task<RegisterationResponse> Register(RegisterationRequest request,int role=0);

    }
}
