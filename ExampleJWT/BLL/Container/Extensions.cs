using ExampleJWT.BLL.Abstract;
using ExampleJWT.BLL.Concrete;
using ExampleJWT.DAL.Abstract;
using ExampleJWT.DAL.Concrete;
using ExampleJWT.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.BLL.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EFUserDal>();

            services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();
        }
    }
}
