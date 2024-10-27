using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CompanyDtos;

namespace TransportationSystem.Applciation.Features.CompanyManage.Requests.Queries
{
    public class GetUsersForCompanyRequest:IRequest<IReadOnlyList<UsersCompanyDto>>
    {
        public long CompanyId{ get; set; }
    }
}
