using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;

namespace TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository
{
    public interface ICompanyRepository:IGenericRepository<TransportCompany>
    {
        Task<bool> CompanyExistByRegisterationNumberAsync(string registerationNaumber);
        Task AddUsersForCompanyAsync(long companyId, List<int> usersId);
    }
}
