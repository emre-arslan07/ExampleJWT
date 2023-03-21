using ExampleJWT.DAL.Abstract;
using ExampleJWT.DAL.EntityFramework;
using ExampleJWT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExampleJWT.DAL.Concrete
{
    public class GenericUnitOfWorkRepository<T> : IGenericUnitOfWorkDal<T> where T : BaseEntity
    {
        private readonly JWTDbContext _jWTDbContext;

        public GenericUnitOfWorkRepository(JWTDbContext jWTDbContext)
        {
            _jWTDbContext = jWTDbContext;
        }

        public DbSet<T> Table => _jWTDbContext.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public Task<bool> AddRangeAsync(List<T> datas)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await _jWTDbContext.Set<T>().SingleOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<T> datas)
        {
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Added;
        }
    }
}
