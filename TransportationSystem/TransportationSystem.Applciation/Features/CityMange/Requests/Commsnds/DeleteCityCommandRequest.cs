using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CityMange.Requests.Commsnds
{
    public class DeleteCityCommandRequest:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
    }
}
