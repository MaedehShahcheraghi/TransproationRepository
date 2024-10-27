using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.DTOs.Common;

namespace TransportationSystem.Applciation.DTOs.CompanyDtos
{
    public class EditCompanyDto: BaseDto,ICompanyDto
    {
        public long Id { get; set; }
        public int Company_Code { get; set; }
        public string Company_Name { get; set; }
        public string RegisterationNumber { get; set; }
        public string Address { get; set; }
    }
}
