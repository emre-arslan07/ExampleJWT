using ExampleJWT.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.DAL.UnitOfWork
{
    public class UnitOfWorkDal : IUnitOfWorkDal
    {
        private readonly JWTDbContext _jWTDbContext;

        public UnitOfWorkDal(JWTDbContext jWTDbContext)
        {
            _jWTDbContext = jWTDbContext;
        }

        public async Task<int> SaveAsync()
        {
          return await _jWTDbContext.SaveChangesAsync();
        }
    }
}
