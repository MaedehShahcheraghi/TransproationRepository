using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Contracts.Persistence.RoleRepository;
using TransportationSystem.Domain.Entities.UserEntities;
using TransportationSystem.Persistence.Context;

namespace TransportationSystem.Persistence.Repositories.RoleRepositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepositories
    {
        private readonly TransportationDbContext _dbContext;

        public RoleRepository(TransportationDbContext dbContext, IStoreProcedureCreator procedureCreator) : base(dbContext, procedureCreator)
        {
            _dbContext = dbContext;
        }
    }
}
