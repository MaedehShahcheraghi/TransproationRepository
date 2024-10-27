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
    public class CompanyRepository : GenericRepository<TransportCompany>, ICompanyRepository
    {
        private readonly TransportationDbContext _dbContext;
        private readonly IStoreProcedureCreator _storeProcedure;

        public CompanyRepository(TransportationDbContext dbContext, IStoreProcedureCreator storeProcedure) : base(dbContext, storeProcedure)
        {
            _dbContext = dbContext;
            _storeProcedure = storeProcedure;
        }

        public async Task AddUsersForCompanyAsync(long companyId, List<int> usersId)
        {
            foreach (var user in usersId) {
               await _dbContext.UserCompanies.AddAsync(new UserCompany()
                {
                    CompanyId = companyId,
                    UserId = user
                });
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CompanyExistByRegisterationNumberAsync(string registerationNaumber)
        {
            return await _dbContext.TransportCompanies.AnyAsync(c => c.RegisterationNumber == registerationNaumber);
        }
    }
}
