using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CompanyDtos;

namespace TransportationSystem.Applciation.Features.CompanyManage.Requests.Queries
{
    public class GetAllCompaniesRequest:IRequest<IReadOnlyList<CompanyDto>>
    {
    }
}
