using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.Common;

namespace TransportationSystem.Applciation.DTOs.CityDTOS
{
    public interface ICityDto
    {
        public int City_Code { get; set; }
        public string City_Name { get; set; }

    }
}
