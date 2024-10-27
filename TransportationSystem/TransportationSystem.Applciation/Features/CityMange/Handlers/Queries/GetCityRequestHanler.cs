using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CityRepository;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.Exceptions;
using TransportationSystem.Applciation.Features.CityMange.Requests.Queries;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CityMange.Handlers.Queries
{
    public class GetCityRequestHanler : IRequestHandler<GetCityRequest, BaseRequestResponse<CityListDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityRequestHanler(ICityRepository cityRepository,IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<BaseRequestResponse<CityListDto>> Handle(GetCityRequest request, CancellationToken cancellationToken)
        {
            var response=new BaseRequestResponse<CityListDto>();
            var data=await _cityRepository.GetByIdAsync(request.Id);
            if (data == null) {
                response.Success=false;
                response.Message = "City NotFound";

            }
            else
            {
                response.Success=true;
                response.Data = _mapper.Map<CityListDto>(data);
                response.Message = "City Found";
            }
          
            return response;
        }
    }
}
