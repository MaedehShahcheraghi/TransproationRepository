using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CityRepository;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.Features.CityMange.Requests.Queries;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CityMange.Handlers.Queries
{
    public class GetCityByCityCodeRequestHandler : IRequestHandler<GetCityByCityCodeRequest, BaseRequestResponse<CityListDto>>
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public GetCityByCityCodeRequestHandler(ICityRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseRequestResponse<CityListDto>> Handle(GetCityByCityCodeRequest request, CancellationToken cancellationToken)
        {
            var response= new BaseRequestResponse<CityListDto>();
            var data = await _repository.GetCityByCity_CodeAsync(request.CityCode);
            if (data != null)
            {
                response.Success = true;
                response.Data = _mapper.Map<CityListDto>(data);
                response.Message = "Get data by CityCode Successfully";
            }
            else
            {
                response.Success= false;
                response.Message = "Not Found City By CityCode";
            }
            return response;
        }
    }
}
