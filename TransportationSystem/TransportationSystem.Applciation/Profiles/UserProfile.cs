using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.UserDtos;
using TransportationSystem.Domain.Entities.UserEntities;
using TransportationSystem.Domain.Entities.UserEntity;

namespace TransportationSystem.Applciation.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            #region User
            CreateMap<User,CreateUserDto>().ReverseMap();
            CreateMap<User,EditUserDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<AddUserRoleDto,UserRole>().ReverseMap();
            CreateMap<BaseUserRoleDto,UserRole>().ReverseMap();

            #endregion
        }

    }
}
