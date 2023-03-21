using ExampleJWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.DAL.EntityFramework
{
    public class JWTDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            dbContextOptions.UseNpgsql("Server=localhost;Port=5432;Database=JWTDB;User Id=postgres;Password=123456");
        }

        public DbSet<User> Users { get; set; }
    }
}
