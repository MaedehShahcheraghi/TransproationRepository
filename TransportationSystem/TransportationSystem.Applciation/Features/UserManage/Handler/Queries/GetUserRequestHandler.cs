using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.Features.UserManage.Request.Queries;

namespace TransportationSystem.Applciation.Features.UserManage.Handler.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {

            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetByIdAsync(request.Id);
            var MapData = _mapper.Map<UserDto>(response);
            return MapData;
        }
    }
}
