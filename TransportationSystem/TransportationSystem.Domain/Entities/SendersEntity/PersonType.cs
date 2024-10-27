using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Domain.Entities.SendersEntity
{
    public class PersonType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PType_Id { get; set; }
        public string PType_Name { get;set; }

        #region Relations
        public ICollection<Sender> Senders { get; set; }
        #endregion
    }
}
