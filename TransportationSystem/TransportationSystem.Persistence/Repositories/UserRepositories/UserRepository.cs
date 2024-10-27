using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Domain.Entities.UserEntity;
using TransportationSystem.Persistence.Context;

namespace TransportationSystem.Persistence.Repositories.UserRepositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TransportationDbContext _dbContext;

        public UserRepository(TransportationDbContext dbContext, IStoreProcedureCreator procedureCreator) : base(dbContext, procedureCreator)
        {
            _dbContext = dbContext;
        }

        public async Task AddRoleForUserAsync(long userId, List<int> Roles)
        {
            foreach (var role in Roles)
            {
                await _dbContext.UserRoles.AddAsync(new Domain.Entities.UserEntities.UserRole()
                {
                    User_Id = userId,
                    Role_Id = (long)role
                });
  
            }
          await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserforLogin(string userName, string password, string? nationalCode)
        {
            var user = await _dbContext.Users.Include(u => u.UserRoles).ThenInclude(u => u.Role).Where(u => u.UserName == userName && u.Password == password).FirstOrDefaultAsync();
            if (nationalCode != null && user.National_Code != null)
            {
                return (user.National_Code == nationalCode ? user : throw new NotImplementedException());
            }
            return user;
        }

        public async Task<bool> UserExistByEmailAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UserExistByNationalcodeAsync(string ncode)
        {
            return await (_dbContext.Users.AnyAsync(u => u.National_Code == ncode));
        }

        public async Task<bool> UserExistByPhoneNumberAsync(string phone)
        {
            return await (_dbContext.Users.AnyAsync(u => u.Phone == phone));
        }

        public async Task<bool> UserExistByUserNameAsync(string userName)
        {
            return await (_dbContext.Users.AnyAsync(u => u.UserName == userName));
        }
    }
}
