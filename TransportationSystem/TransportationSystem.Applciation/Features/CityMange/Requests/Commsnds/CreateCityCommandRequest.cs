using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CityMange.Requests.Commsnds
{
    public class CreateCityCommandRequest:IRequest<BaseCommandResponse>
    {
        public CreateCityDto CityDto { get; set; }
    }
}
