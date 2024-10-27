using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.CityDTOS
{
    public class CityListDto: ICityDto
    {
        public int City_Code { get; set; }
        public string City_Name { get; set; }
    }
}
