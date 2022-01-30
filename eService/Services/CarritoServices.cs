using eInfrastructure.Contexts;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using eInfrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Services
{
    public class CarritoServices
    {
        private readonly CarritoRepository repositorio;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuraciones"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpContextAccessor"></param>
        public CarritoServices(ConfiguracionesModel configuraciones, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            repositorio = new CarritoRepository(configuraciones, dbContext, httpContextAccessor);
        }

        /// <summary>
        /// Agregar al Carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public ResponseModel Agregar(ParamAgregarCarritoModel parametro)
        {
            return repositorio.Agregar(parametro);
        }
    }
}
