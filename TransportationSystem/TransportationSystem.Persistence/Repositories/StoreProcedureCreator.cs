using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Models.SP_Model;

namespace TransportationSystem.Persistence.Repositories
{
    public class StoreProcedureCreator : IStoreProcedureCreator
    {
        public async Task<string> CreateStoredProcedure(string procedureName, List<StoredProcedureParameter> parameters, string body)
        {
            string parameterDefinition = string.Join(", ", parameters.ConvertAll(p => $"{p.Name} {p.Type}"));

            string procedure = $"CREATE PROCEDURE {procedureName} {parameterDefinition} AS BEGIN {body} END";
            return procedure ;
        }
    }

}
