using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepositories;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.Features.UserManage.Request.Queries;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.UserManage.Handler.Queries
{
    public class GetAllUserRoleRequestHandler : IRequestHandler<GetAllUserRoleRequest, BaseRequestResponse<ICollection<BaseUserRoleDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;

        public GetAllUserRoleRequestHandler(IMapper mapper,IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
        }
        public async Task<BaseRequestResponse<ICollection<BaseUserRoleDto>>> Handle(GetAllUserRoleRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseRequestResponse<ICollection<BaseUserRoleDto>>();
            var data = await _userRoleRepository.GetAllAsync();
            response.Success = true;
            response.Data =  _mapper.Map<ICollection<BaseUserRoleDto>>(data);
            response.Message = "Get Data was successfully";
            return response;

        }
    }
}
