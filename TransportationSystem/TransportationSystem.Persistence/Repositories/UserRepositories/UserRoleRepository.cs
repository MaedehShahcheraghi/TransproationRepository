using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepositories;
using TransportationSystem.Domain.Entities.UserEntities;
using TransportationSystem.Persistence.Context;

namespace TransportationSystem.Persistence.Repositories.UserRepositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly TransportationDbContext _dbContext;

        public UserRoleRepository(TransportationDbContext dbContext, IStoreProcedureCreator procedureCreator) : base(dbContext, procedureCreator)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<UserRole>> GetRolesByUserId(long userId)
        {
            var  result=await _dbContext.UserRoles.Where(u=> u.User_Id==userId).ToListAsync();
            return result;
        }

    }
}
