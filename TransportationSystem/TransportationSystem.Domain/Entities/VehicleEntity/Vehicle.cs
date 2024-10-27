using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.VehicleEntity
{
    public class Vehicle: BaseEntity
    {

        public string Card_No { get; set; }
        public string Plate_No { get; set; }
        public string Plate_Serial_No { get; set; }
        public int F_Vehicle_Systems_ID { get; set; }
        public string Vehicle_System_Type_Name { get; set; }
        public int F_Trailer_Types_ID { get; set; }
        public string Shasi_No { get; set; }
        public string VIN { get; set; }
        public int Built_Year { get; set; }
        public string Amar_No { get; set; }
        public int F_Issued_City_ID { get; set; }
        public bool IsActive { get; set; }


        #region Relations
    }
    #endregion

}
