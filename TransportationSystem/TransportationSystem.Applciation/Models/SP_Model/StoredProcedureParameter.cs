using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Models.SP_Model
{
    public class StoredProcedureParameter
    {
        public string Name { get; set; }
        public string Type { get; set; } // e.g., "INT", "NVARCHAR(50)"
        public object Value { get; set; } // The value to be passed to the parameter
    }

}
