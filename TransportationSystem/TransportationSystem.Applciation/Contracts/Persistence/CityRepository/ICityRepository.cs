using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Citites;

namespace TransportationSystem.Applciation.Contracts.Persistence.CityRepository
{
    public interface ICityRepository:IGenericRepository<City>
    {
        City GetCityByCity_Code(int cityCode);

        #region AsyncMethods
        Task<City> GetCityByCity_CodeAsync(int cityCode);   
        

        #endregion
    }
}
