using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CityRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.Features.UserManage.Request.Queries;

namespace TransportationSystem.Applciation.Features.UserManage.Handler.Queries
{
    public class GetAllUserRequestHandler : IRequestHandler<GetAllUserRequest, IReadOnlyList<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetAllUserRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<IReadOnlyList<UserDto>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetAllAsync();
            var MapData = _mapper.Map<IReadOnlyList<UserDto>>(response);
            return MapData;
        }
    }
}
