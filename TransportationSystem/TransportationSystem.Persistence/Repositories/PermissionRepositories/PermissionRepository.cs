using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Contracts.Persistence.PermissionRepository;
using TransportationSystem.Applciation.Contracts.Persistence.RoleRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepositories;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Domain.Entities.UserEntities;
using TransportationSystem.Persistence.Context;

namespace TransportationSystem.Persistence.Repositories.PermissionRepositories
{
    public class PermissionRepository:GenericRepository<Permission>,IPermissionRepository
    {
        private readonly TransportationDbContext _dbContext;
        private readonly IRolePermissionRepository _permissionRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;

        public PermissionRepository(TransportationDbContext dbContext,
            IRolePermissionRepository permissionRepository,IUserRoleRepository userRoleRepository,IUserRepository userRepository, IStoreProcedureCreator procedureCreator) : base(dbContext, procedureCreator)
        {
            _dbContext = dbContext;
            _permissionRepository = permissionRepository;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> CheckPermissionUser(string userName, int permissionId)
        {
            var user=await _dbContext.Users.FirstOrDefaultAsync(u=> u.UserName == userName);
            if (user != null)
            {
                var userroles=await _userRoleRepository.GetRolesByUserId(user.Id);
                var roles = userroles.Select(u => u.Role_Id).ToList();
                var rolepermission=await _permissionRepository.GetAllRolesForPermission(permissionId);
                var permissions = rolepermission.Select(u => u.Role_Id).ToList();
                var result = permissions.Any(u => roles.Contains(u));
                return  await Task.FromResult(result);

            }
            else
            {
                return await Task.FromResult(false);
            }
        }
    }
}
