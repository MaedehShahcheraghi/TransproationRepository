using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;

namespace TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository
{
    public interface IUserCompanyRepository:IGenericRepository<UserCompany>
    {
        Task<List<UserCompany>> GetUserByCompanyID(long CompanyId);
    }
}
