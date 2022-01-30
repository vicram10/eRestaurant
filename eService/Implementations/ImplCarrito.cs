using eInfrastructure.Contexts;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using eService.Interfaces;
using eService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Implementations
{
    public class ImplCarrito : ICarrito
    {
        private readonly CarritoServices services;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpContextAccessor"></param>
        public ImplCarrito(IOptions<ConfiguracionesModel> options, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            services = new CarritoServices(options.Value, dbContext, httpContextAccessor);
        }

        /// <summary>
        /// Agregar al Carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public ResponseModel Agregar(ParamAgregarCarritoModel parametro)
        {
            return services.Agregar(parametro);
        }
    }
}
