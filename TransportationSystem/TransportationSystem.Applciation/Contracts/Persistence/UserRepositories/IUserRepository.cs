using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.UserEntity;

namespace TransportationSystem.Applciation.Contracts.Persistence.UserRepository
{
    public interface IUserRepository:IGenericRepository<User>
    {


        #region AsyncMethod
        Task<bool> UserExistByEmailAsync(string email);
        Task<bool> UserExistByPhoneNumberAsync(string phone);
        Task<bool> UserExistByNationalcodeAsync(string ncode);
        Task<bool> UserExistByUserNameAsync(string userName);

        Task<User> GetUserforLogin(string userName,string password,string? nationalCode);
        Task AddRoleForUserAsync(long userId,List<int> Roles);
        #endregion
    }
}
