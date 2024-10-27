using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.VehicleEntity
{
    internal class TrailerTypes:BaseEntity
    {
        public int F_Trailer_Types_ID { get; set; }
        public string Trailer_Type_Name { get; set; }
    }
}
