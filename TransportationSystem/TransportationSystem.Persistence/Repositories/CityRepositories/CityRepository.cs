using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Contracts.Persistence.CityRepository;
using TransportationSystem.Domain.Entities.Citites;
using TransportationSystem.Persistence.Context;

namespace TransportationSystem.Persistence.Repositories.CityRepositories
{
    public class CityRepository : GenericRepository<City>,ICityRepository
    {
        private readonly TransportationDbContext _dbContext;
        private readonly IStoreProcedureCreator _storeProcedure;

        public CityRepository(TransportationDbContext dbContext,IStoreProcedureCreator storeProcedure):base(dbContext,storeProcedure) 
        {
            _dbContext = dbContext;
            _storeProcedure = storeProcedure;
        }
        public  City GetCityByCity_Code(int cityCode)
        {
            var data =  _dbContext.Cities.SingleOrDefault(c => c.City_Code == cityCode);
            
            return  data;
        }

        public async Task<City> GetCityByCity_CodeAsync(int cityCode)
        {

            var data = await _dbContext.Cities.FirstOrDefaultAsync(c => c.City_Code == cityCode);
            return data;
        }
    }
}
