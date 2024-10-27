using Azure.Core;
using MediatR;

using Microsoft.AspNetCore.Mvc;
using TransportationSystem.Applciation.Contracts.Infrrastructure.Services;
using TransportationSystem.Applciation.Models.User_Model;
using TransportationSystem.Applciation.Responses.UserResponse;

namespace TransportationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;

        public AccountController(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }
        #region Login
        [HttpPost("/Login")]
        public async Task<ActionResult<AuthResponse>> LoginUser(AuthRequest authRequest)
        {
            var reslut = await _authentication.Login(authRequest);
            return Ok(reslut);
        }
        #endregion
        #region Register

        [HttpPost("/Register/{role}")]
        public async Task<ActionResult<RegisterationResponse>> RegisterUser(RegisterationRequest request,int role=0)
        {
            var reslut = await _authentication.Register(request,role);
            return Ok(reslut);

        }

        #endregion
    }
}
