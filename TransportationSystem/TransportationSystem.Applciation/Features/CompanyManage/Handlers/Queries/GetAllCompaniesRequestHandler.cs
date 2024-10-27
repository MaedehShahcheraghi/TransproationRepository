using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CityRepository;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.DTOs.CompanyDtos;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Queries;

namespace TransportationSystem.Applciation.Features.CompanyManage.Handlers.Queries
{
    public class GetAllCompaniesRequestHandler : IRequestHandler<GetAllCompaniesRequest, IReadOnlyList<CompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;


        public GetAllCompaniesRequestHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;

        }
        public async Task<IReadOnlyList<CompanyDto>> Handle(GetAllCompaniesRequest request, CancellationToken cancellationToken)
        {
            var response = await _companyRepository.GetAllAsync();
            var MapData = _mapper.Map<IReadOnlyList<CompanyDto>>(response);
            return MapData;
        }
    }
}
