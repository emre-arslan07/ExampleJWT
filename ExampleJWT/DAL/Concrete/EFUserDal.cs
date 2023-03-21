using ExampleJWT.DAL.Abstract;
using ExampleJWT.DAL.EntityFramework;
using ExampleJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.DAL.Concrete
{
    public class EFUserDal:GenericUnitOfWorkRepository<User>,IUserDal
    {
        public EFUserDal(JWTDbContext jWTDbContext):base(jWTDbContext)
        {

        }
    }
}
