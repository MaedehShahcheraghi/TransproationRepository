using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Domain.Entities.Citites;

namespace TransportationSystem.Applciation.Profiles
{
    public class CityProfile:Profile
    {
        public CityProfile()
        {
               CreateMap<City,CityListDto>().ReverseMap();
               CreateMap<City,CreateCityDto>().ReverseMap();
               CreateMap<City,EditCityDto>().ReverseMap();
        }
    }
}
