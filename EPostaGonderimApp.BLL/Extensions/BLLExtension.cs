using EPostaGonderimApp.BLL.Abstract;
using EPostaGonderimApp.BLL.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.BLL.Extensions
{
    public static class BLLExtension
    {
        public static IServiceCollection AddBLLExtensions(this IServiceCollection service)
        {
            service.AddScoped<IKisiService, KisiService>();
            service.AddScoped<IEPostaAdresService, EPostaAdresService>();
            service.AddScoped<IEPostaService, EPostaService>();
            var assembly = Assembly.GetExecutingAssembly();
            service.AddAutoMapper(assembly);
            return service;
        }
    }
}
