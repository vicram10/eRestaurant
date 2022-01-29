using eInfrastructure.Contexts;
using eInfrastructure.Models;
using eInfrastructure.Models.Producto;
using eInfrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Services
{
    public class ProductoServices
    {
        private readonly ProductosRepository repositorio;

        public ProductoServices(ConfiguracionesModel configuraciones, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            repositorio = new ProductosRepository(configuraciones, dbContext, httpContextAccessor);
        }

        /// <summary>
        /// para poder dar de alta productos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public ResponseModel Alta(ParamProductoAltaModel producto)
        {
            return repositorio.Alta(producto);
        }
    }
}
