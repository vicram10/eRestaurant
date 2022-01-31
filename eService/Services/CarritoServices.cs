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
        /// Verificacion de pago
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <returns></returns>
        public ResponseModel VerificarPago(string DocumentoID)
        {
            return repositorio.VerificarPago(DocumentoID);
        }

        /// <summary>
        /// actualizacion a pagado
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <returns></returns>
        public ResponseModel ActualizarPago(string DocumentoID)
        {
            return repositorio.ActualizarPago(DocumentoID);
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
    }
}
