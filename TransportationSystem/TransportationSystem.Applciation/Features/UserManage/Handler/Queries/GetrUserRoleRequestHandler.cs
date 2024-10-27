using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepositories;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.Features.UserManage.Request.Queries;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.UserManage.Handler.Queries
{
    public class GetrUserRoleRequestHandler : IRequestHandler<GetrUserRoleRequest, BaseRequestResponse<ICollection<BaseUserRoleDto>>>
    {
     
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public GetrUserRoleRequestHandler(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
             _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }
        public async Task<BaseRequestResponse<ICollection<BaseUserRoleDto>>> Handle(GetrUserRoleRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseRequestResponse<ICollection<BaseUserRoleDto>>();
            var data = await _userRoleRepository.GetRolesByUserId(request.UserId);
            response.Success = true;
            response.Data = _mapper.Map<ICollection<BaseUserRoleDto>>(data);
            response.Message = "Get Data was successfully";
            return response;
        }
    }
}
