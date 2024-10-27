using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.Responses.BaseResponse;
using TransportationSystem.Domain.Entities.Citites;

namespace TransportationSystem.Applciation.Features.CityMange.Requests.Queries
{
    public class GetCityRequest:IRequest<BaseRequestResponse<CityListDto>>
    {
        public long Id { get; set; }
    }
}
