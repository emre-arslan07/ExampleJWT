using ExampleJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.BLL.Abstract
{
   public interface IUserService:IGenericUnitOfWorkService<User>
    {
        Task<User> GetSingleByRefreshTokenAsync(string token);
    }
}
