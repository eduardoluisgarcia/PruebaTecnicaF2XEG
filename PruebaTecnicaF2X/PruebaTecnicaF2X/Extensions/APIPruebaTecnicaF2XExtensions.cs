using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Interfaces;
using PruebaTecnicaF2X.Services;
using PruebaTecnicaF2X.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace PruebaTecnicaF2X.Extensions
{
    public static class APIPruebaTecnicaF2XExtensions
    {
        public static IServiceCollection AddAPIPruebaTecnicaF2XExtensions(this IServiceCollection services)
        {
            services.AddScoped<IRecaudosService, RecaudosService>();
            services.AddScoped<IRecaudosRepository, RecaudosRepository>();

            services.AddScoped<IDatosVehiculosService, DatosVehiculosService>();
            services.AddScoped<IDatosVehiculosRepository, DatosVehiculosRepository>();
            
            services.AddScoped<IReporteService, ReporteService>();
            services.AddScoped<IReporteRepository, ReporteRepository>();

            return services;
        }
    }
}
