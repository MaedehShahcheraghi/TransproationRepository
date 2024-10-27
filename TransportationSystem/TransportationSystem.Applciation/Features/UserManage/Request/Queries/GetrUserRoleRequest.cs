using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Applciation.Features.UserManage.Request.Queries
{
    public class GetrUserRoleRequest:IRequest<BaseRequestResponse<ICollection<BaseUserRoleDto>>>
    {
        public int UserId { get; set; }
    }
}
