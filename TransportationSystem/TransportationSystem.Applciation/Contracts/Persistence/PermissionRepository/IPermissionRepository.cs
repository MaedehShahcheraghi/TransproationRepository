using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.UserEntities;

namespace TransportationSystem.Applciation.Contracts.Persistence.PermissionRepository
{
    public interface IPermissionRepository:IGenericRepository<Permission>
    {
        Task<bool> CheckPermissionUser(string userName, int permissionId);

    }
}
