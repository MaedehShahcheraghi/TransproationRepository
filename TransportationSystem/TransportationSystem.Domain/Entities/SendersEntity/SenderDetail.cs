using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.SendersEntity
{
    public class SenderDetail:BaseEntity
    {
                                                                                                                          
       
        //Legal Person
       
        public string? Company_Name { get; set; }
        public string? Identification_code { get; set; }
        public string? National_ID_code { get; set; }
        public string? Economic_code { get; set; }
        public string? branch_name { get; set; }
        public string? branch_Code { get; set; }

        //Real Person

        public string? RealName { get; set; }
        public string? LastName { get; set; }
        public string? National_Code { get; set; }

        //Person Type

        public int PType_Id { get; set; }

        //Sender
        public int Sender_Code { get; set; }

        #region Relations

        [ForeignKey("PType_Id")]
        public PersonType PersonType { get; set; }

        #endregion
    }
}
