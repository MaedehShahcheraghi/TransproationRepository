using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Domain.Entities.Common
{
    public interface BaseAddres
    {

        public string Phone { get; set; }
        public string Fax { get; set; }
        public int CityCode { get; set; }
        public int Post_Code { get; set; }
    }
}
