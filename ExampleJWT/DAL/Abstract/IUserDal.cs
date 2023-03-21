using ExampleJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.DAL.Abstract
{
   public interface IUserDal:IGenericUnitOfWorkDal<User>
    {
    }
}
