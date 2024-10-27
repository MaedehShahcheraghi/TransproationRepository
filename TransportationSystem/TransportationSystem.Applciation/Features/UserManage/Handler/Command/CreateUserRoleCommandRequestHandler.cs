using AutoMapper;
using MediatR;
using TransportationSystem.Applciation.Contracts.Persistence.RoleRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepositories;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.DTOs.UserDtos.Validators;
using TransportationSystem.Applciation.Features.UserManage.Request.Command;
using TransportationSystem.Applciation.Responses.BaseResponse;
using TransportationSystem.Domain.Entities.UserEntities;

namespace TransportationSystem.Applciation.Features.UserManage.Handler.Command
{
    public class CreateUserRoleCommandRequestHandler : IRequestHandler<CreateUserRoleCommandRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepositories _roleRepositories;
        private readonly IUserRoleRepository _userRoleRepository;

        public CreateUserRoleCommandRequestHandler(IMapper mapper,IUserRepository userRepository ,IRoleRepositories roleRepositories,IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepositories = roleRepositories;
            _userRoleRepository = userRoleRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var response=new BaseCommandResponse();
            var userroles=new List<AddUserRoleDto>();
            foreach (var role in request.UserRole.roleIds)
            {
                var userrole = new AddUserRoleDto()
                {
                    Role_Id = role,
                    User_Id = request.UserRole.User_Id
                };
               
                var validate = await new AddUserRoleDtoValidator(_userRepository,_roleRepositories).ValidateAsync(userrole);
                if (!validate.IsValid)
                {
                    response.ErrorMessages.AddRange(validate.Errors.Select(x => x.ErrorMessage).ToList());
                }
                else {
                    userroles.Add(userrole);
                }
                  
            }
            if (userroles.Count > 0) { 
                    var data=_mapper.Map<List<UserRole>>(userroles);
                    await _userRoleRepository.AddRangeAsync(data);
                    response.Success = true;
                response.Message = "creation roles successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "creation roles failed";
            }
            return response;
          
        }
    }
}
