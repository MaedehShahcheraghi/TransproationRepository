using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CityMange.Requests.Queries
{
    public class GetCityByCityCodeRequest:IRequest<BaseRequestResponse<CityListDto>>
    {
        public int CityCode { get; set; }
    }
}
