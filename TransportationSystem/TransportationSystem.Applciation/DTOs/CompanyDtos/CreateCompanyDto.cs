using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.CompanyDtos
{
    public class CreateCompanyDto:ICompanyDto
    {
        public int Company_Code { get; set; }
        public string Company_Name { get; set; }
        public string RegisterationNumber { get; set; }
        public string Address { get; set; }
    }
}
