using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CompanyDtos;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;

namespace TransportationSystem.Applciation.Profiles
{
    public class CompanyProfile:Profile
    {
        public CompanyProfile()
        {
            CreateMap<TransportCompany,CreateCompanyDto>().ReverseMap();
            CreateMap<TransportCompany,EditCompanyDto>().ReverseMap();
            CreateMap<TransportCompany,CompanyDto>().ReverseMap();
            CreateMap<UserCompany,AddUserCompaniesDto>().ReverseMap();
            CreateMap<UsersCompanyDto,UserCompany>().ReverseMap();
        }
    }
}
