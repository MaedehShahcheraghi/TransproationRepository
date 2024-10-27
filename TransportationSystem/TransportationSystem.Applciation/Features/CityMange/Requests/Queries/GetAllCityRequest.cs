using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CityDTOS;

namespace TransportationSystem.Applciation.Features.CityMange.Requests.Queries
{
    public class GetAllCityRequest:IRequest<IReadOnlyList<CityListDto>>
    {
     
    }
}
