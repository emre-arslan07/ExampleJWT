using ExampleJWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.DAL.Abstract
{
   public interface IRepository<T> where T:BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
