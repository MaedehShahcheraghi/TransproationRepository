using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.VehicleEntity
{
    public class VehicleSystemType:BaseEntity
    {
        public int F_Vehicle_Systems_ID { get; set; }
        public string Vehicle_System_Name { get; set; }
    }
}
