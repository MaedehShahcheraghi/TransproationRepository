using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class  
    {
        IReadOnlyList<T> GetAll();
        T GetById(object id);
        T Add(T item);
        void Update(T item);
        void Delete(T item);
        bool Exist(object id);

        #region AsyncMethods
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> AddAsync(T item);
        Task AddRangeAsync(ICollection<T> items);
        Task UpdateAsync(T item);
        Task DeleteAsync(long id);
        Task<bool> ExistAsync(object id);    
        #endregion


    }

}
