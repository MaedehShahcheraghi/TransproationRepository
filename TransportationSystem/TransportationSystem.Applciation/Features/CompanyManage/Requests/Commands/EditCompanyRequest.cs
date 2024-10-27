using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CompanyDtos;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.CompanyManage.Requests.Commands
{
    public class EditCompanyRequest:IRequest<BaseCommandResponse>
    {
        public EditCompanyDto EditCompanyDto { get; set; }
    }
}
