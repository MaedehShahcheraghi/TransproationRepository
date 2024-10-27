using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.DTOs.CompanyDtos;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Queries;

namespace TransportationSystem.Applciation.Features.CompanyManage.Handlers.Queries
{
    public class GetUsersForCompanyRequestHandler : IRequestHandler<GetUsersForCompanyRequest, IReadOnlyList<UsersCompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserCompanyRepository _userCompanyRepository;



        public GetUsersForCompanyRequestHandler(IMapper mapper, IUserCompanyRepository userCompanyRepository)
        {
            _mapper = mapper;
            _userCompanyRepository = userCompanyRepository;


        }


        public async Task<IReadOnlyList<UsersCompanyDto>> Handle(GetUsersForCompanyRequest request, CancellationToken cancellationToken)
        {
            var response = await _userCompanyRepository.GetUserByCompanyID(request.CompanyId);
            var MapData = _mapper.Map<IReadOnlyList<UsersCompanyDto>>(response);
            return MapData;
        }
    }
}
