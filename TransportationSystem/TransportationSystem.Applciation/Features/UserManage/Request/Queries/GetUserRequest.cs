using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.UserDtos;

namespace TransportationSystem.Applciation.Features.UserManage.Request.Queries
{
    public class GetUserRequest:IRequest<UserDto>
    {
        public long Id { get; set; }
    }
}
