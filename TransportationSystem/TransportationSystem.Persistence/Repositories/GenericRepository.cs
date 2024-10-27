using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Models.SP_Model;
using TransportationSystem.Persistence.Context;

namespace TransportationSystem.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TransportationDbContext _dbContext;
        private readonly IStoreProcedureCreator _procedureCreator;
        private readonly DbSet<T> _dbset;
        public GenericRepository(TransportationDbContext dbContext, IStoreProcedureCreator procedureCreator)
        {
            _dbContext = dbContext;
            _procedureCreator = procedureCreator;
            _dbset = _dbContext.Set<T>();
        }
        public T Add(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<T> AddAsync(T item)
        {
            await _dbset.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task AddRangeAsync(ICollection<T> items)
        {
            await _dbset.AddRangeAsync(items);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(long Id)
        {
            var data=await GetByIdAsync(Id);
            if (data != null) { 
                _dbset.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool Exist(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistAsync(object id)
        {
           await _dbset.FindAsync(id);
            return true;
        }

        public IReadOnlyList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(object id)
        {

            //var param = new List<StoredProcedureParameter>()
            //{
            //    new StoredProcedureParameter()
            //    {
            //          Name = "@id",
            //    Type = "INT",
            //    Value = id
            //    }
            //};

            //string body = $"SELECT * FROM {nameof(_dbContext.Cities)} where Id=@id ";
            //string prcedure = await _procedureCreator.CreateStoredProcedure("GetById", param, body);

            //_dbContext.Database.ExecuteSqlRaw(prcedure);
           /* var result = await _dbset.FromSqlRaw($"EXEC GetById {id}").ToListAsync()*/;

            return await _dbset.FindAsync(id) ;
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T item)
        {
            _dbset.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
