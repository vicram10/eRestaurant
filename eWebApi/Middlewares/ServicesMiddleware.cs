using eInfrastructure.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edWebApi.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AgregarDependencia(IServiceCollection services) {

            ///para poder usar las interfaces
            ///
            //services.AddTransient<IApiUsuario, ImplApiUsuario>();

            ///para poder usar las variables de session
            ///
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>(); //Para las variables de session

            ///para poder tener distintos idiomas por usuario
            ///
            services.AddScoped<Localization>();
        }
    }
}
