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
    public class GetAllCityRequestHandler : IRequestHandler<GetAllCityRequest, IReadOnlyList<CityListDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetAllCityRequestHandler(ICityRepository cityRepository,IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<CityListDto>> Handle(GetAllCityRequest request, CancellationToken cancellationToken)
        {
            var response = await _cityRepository.GetAllAsync();
            var MapData=_mapper.Map<IReadOnlyList<CityListDto>> (response);
            return MapData;
        }

    }
}

