using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Models.SP_Model;

namespace TransportationSystem.Applciation.Contracts.Persistence
{
    public interface IStoreProcedureCreator
    {
        Task<string> CreateStoredProcedure(string procedureName, List<StoredProcedureParameter> parameters, string body);
    }
}
