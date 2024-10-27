using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.UserEntities;
using TransportationSystem.Domain.Entities.UserEntity;

namespace TransportationSystem.Applciation.Contracts.Persistence.UserRepositories
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        Task<ICollection<UserRole>> GetRolesByUserId(long userId);
    }
}
