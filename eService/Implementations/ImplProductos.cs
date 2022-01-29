using eInfrastructure.Contexts;
using eInfrastructure.Models;
using eInfrastructure.Models.Producto;
using eService.Interfaces;
using eService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Implementations
{
    public class ImplProductos : IProductos
    {
        private readonly ProductoServices services;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpContextAccessor"></param>
        public ImplProductos(IOptions<ConfiguracionesModel> options, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            services = new ProductoServices(options.Value, dbContext, httpContextAccessor);
        }

        /// <summary>
        /// para poder dar de alta productos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public ResponseModel Alta(ParamProductoAltaModel producto)
        {
            return services.Alta(producto);
        }
    }
}
