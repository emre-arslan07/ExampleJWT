using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.DAL.UnitOfWork
{
   public interface IUnitOfWorkDal
    {
        Task<int> SaveAsync();
    }
}
