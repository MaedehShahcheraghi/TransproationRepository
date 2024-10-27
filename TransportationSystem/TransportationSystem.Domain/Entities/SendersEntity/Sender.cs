using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Common;

namespace TransportationSystem.Domain.Entities.SendersEntity
{
    public class Sender : BaseEntity,BaseAddres
    {
        public int Sender_Code { get; set; }
        public int PType_Id { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int CityCode { get; set; }
        public int Post_Code { get; set; }

        #region Relations
        [ForeignKey(nameof(PType_Id))]
        public PersonType personType { get; set; }


        #endregion
    }
}
