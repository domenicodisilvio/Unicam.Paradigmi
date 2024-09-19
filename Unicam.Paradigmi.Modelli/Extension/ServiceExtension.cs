using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Modelli.Context;
using Microsoft.Extensions.Configuration;
using Unicam.Paradigmi.Modelli.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Unicam.Paradigmi.Modelli.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(config.GetConnectionString("MyDbContext"));
            });
            services.AddScoped<LibroRepository>();
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<UtenteRepository>();
            return services;
        }
    }
}
