using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.DTOs.CompanyDtos;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Queries;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CompanyManage.Handlers.Queries
{
    public class GetCompantByIdRequestHandler : IRequestHandler<GetCompantByIdRequest, BaseRequestResponse<CompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
      

        public GetCompantByIdRequestHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            
        }
        public async Task<BaseRequestResponse<CompanyDto>> Handle(GetCompantByIdRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseRequestResponse<CompanyDto>();
            var data = await _companyRepository.GetByIdAsync(request.CompanyId);
            if (data != null)
            {
                response.Success = true;
                response.Data = _mapper.Map<CompanyDto>(data);
                response.Message = "Get data by Id Successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Not Found City By CityCode";
            }
            return response;
        }
    }
}
