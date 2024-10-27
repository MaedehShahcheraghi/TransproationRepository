using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.UserEntities;

namespace TransportationSystem.Applciation.Contracts.Persistence.RoleRepository
{
    public interface IRolePermissionRepository:IGenericRepository<RolePermission>
    {
        Task<ICollection<RolePermission>> GetAllRolesForPermission(int peremissionId);
    }
}
