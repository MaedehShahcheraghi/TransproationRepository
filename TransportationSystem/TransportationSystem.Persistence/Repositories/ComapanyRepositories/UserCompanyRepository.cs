using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;
using TransportationSystem.Persistence.Context;

namespace TransportationSystem.Persistence.Repositories.ComapanyRepositories
{
    public class UserCompanyRepository : GenericRepository<UserCompany>, IUserCompanyRepository
    {
        private readonly TransportationDbContext _dbContext;

        public UserCompanyRepository(TransportationDbContext dbContext, IStoreProcedureCreator procedureCreator) : base(dbContext, procedureCreator)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserCompany>> GetUserByCompanyID(long CompanyId)
        {
           return await _dbContext.UserCompanies.Where(u=> u.CompanyId==CompanyId).ToListAsync();

        }
    }
}
