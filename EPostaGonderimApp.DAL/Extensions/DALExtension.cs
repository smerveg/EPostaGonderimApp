using EPostaGonderimApp.DAL.Context;
using EPostaGonderimApp.DAL.Repositories.Abstract;
using EPostaGonderimApp.DAL.Repositories.Concrete;
using EPostaGonderimApp.DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.DAL.Extensions
{
    public static class DALExtension
    {
        public static IServiceCollection AddDALExtensions(this IServiceCollection service,
            IConfiguration config)
        {
            service.AddDbContext<EPostaGonderimContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            return service;
        }
    }
}
