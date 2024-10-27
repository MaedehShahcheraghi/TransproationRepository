using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.Citites
{
    public class City:BaseEntity
    {
        public int City_Code { get; set; }
        public string City_Name { get; set; }

    }
}
