using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.Features.UserManage.Request.Command;
using TransportationSystem.Applciation.Features.UserManage.Request.Queries;

namespace TransportationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/Get_All_User")]
        public async Task<ActionResult> GetAllUser()
        {
            var request = new GetAllUserRequest();
            var result=  await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("/Get_User/{id}")]
        public async Task<ActionResult> GetUser(long id)
        {
            var request = new GetUserRequest() { Id=id};
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("/Add_User")]
        public async Task<ActionResult> AddUser(CreateUserDto createUser)
        {
            var request = new CreateUserCommandRequest() { CreateUser=createUser};
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("/Edit_User")]
        public async Task<ActionResult> EditUser(EditUserDto editUser)
        {
            var request = new EditUserCommandRequest() { EditUser = editUser };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("/Add_User_Role")]
        public async Task<ActionResult> AddUserRole(UserRoleDto userRoleDto)
        {
            var request = new CreateUserRoleCommandRequest() { UserRole = userRoleDto };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("/GetAllUserRole")]
        public async Task<ActionResult> GetAllUserRole()
        {
            var request = new GetAllUserRoleRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("/GetAllUserRole/{user_Id}")]
        public async Task<ActionResult> GetAllUserRole(int user_Id)
        {
            var request = new GetrUserRoleRequest() { UserId=user_Id};
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
