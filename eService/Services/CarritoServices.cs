using eInfrastructure.Contexts;
using eInfrastructure.Entities;
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

        /// <summary>
        /// listamos el carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public List<Carrito> Listar(ParamFiltroBusquedaCarritoModel parametro)
        {
            return repositorio.Listar(parametro);
        }

        /// <summary>
        /// para poder preparar el pago en adamspay
        /// </summary>
        /// <returns></returns>
        public ResponseModel PrepararPago()
        {
            return repositorio.PrepararPago();
        }

        /// <summary>
        /// actualizacion estado carrito
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <param name="estadoCarrito"></param>
        /// <returns></returns>
        public ResponseModel ActualizarCarrito(string DocumentoID, EstadoCarritoModel estadoCarrito)
        {
            return repositorio.ActualizarCarrito(DocumentoID, estadoCarrito);
        }

        /// <summary>
        /// para poder eliminar items
        /// </summary>
        /// <param name="IdCarrito"></param>
        /// <returns></returns>
        public ResponseModel Eliminar(int IdCarrito)
        {
            return repositorio.Eliminar(IdCarrito);
        }

        /// <summary>
        /// Para poder recibir notificaciones desde AdamsPay
        /// </summary>
        /// <param name="hook"></param>
        /// <returns></returns>
        public ResponseModel WebHook(WebHookModel hook)
        {
            return repositorio.WebHook(hook);
        }
    }
}
