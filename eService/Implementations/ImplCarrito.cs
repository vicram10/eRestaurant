using eInfrastructure.Contexts;
using eInfrastructure.Entities;
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

        /// <summary>
        /// listamos el carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public List<Carrito> Listar(ParamFiltroBusquedaCarritoModel parametro)
        {
            return services.Listar(parametro);
        }

        /// <summary>
        /// para poder preparar el pago en adamspay
        /// </summary>
        /// <returns></returns>
        public ResponseModel PrepararPago()
        {
            return services.PrepararPago();
        }

        /// <summary>
        /// actualizacion estado carrito
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <param name="estadoCarrito"></param>
        /// <returns></returns>
        public ResponseModel ActualizarCarrito(string DocumentoID, EstadoCarritoModel estadoCarrito)
        {
            return services.ActualizarCarrito(DocumentoID, estadoCarrito);
        }

        /// <summary>
        /// para poder eliminar items
        /// </summary>
        /// <param name="IdCarrito"></param>
        /// <returns></returns>
        public ResponseModel Eliminar(int IdCarrito)
        {
            return services.Eliminar(IdCarrito);
        }
    }
}
