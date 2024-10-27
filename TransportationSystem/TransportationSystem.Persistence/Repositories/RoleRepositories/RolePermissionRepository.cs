using Microsoft.EntityFrameworkCore;
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
    public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
    {
        private readonly TransportationDbContext _dbContext;

        public RolePermissionRepository(TransportationDbContext dbContext, IStoreProcedureCreator procedureCreator) :base(dbContext,procedureCreator)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<RolePermission>> GetAllRolesForPermission(int peremissionId)
        {
            return await _dbContext.rolePermissions.Where(u=> u.Permission_Id == peremissionId).ToListAsync(); 
        }
    }
}
