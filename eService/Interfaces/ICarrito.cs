using eInfrastructure.Entities;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Interfaces
{
    public interface ICarrito
    {
        /// <summary>
        /// Agregar al Carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        ResponseModel Agregar(ParamAgregarCarritoModel parametro);

        /// <summary>
        /// listamos el carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        List<Carrito> Listar(ParamFiltroBusquedaCarritoModel parametro);

        /// <summary>
        /// para poder preparar el pago en adamspay
        /// </summary>
        /// <returns></returns>
        ResponseModel PrepararPago();

        /// <summary>
        /// Verificacion de pago
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <returns></returns>
        ResponseModel VerificarPago(string DocumentoID);

        /// <summary>
        /// actualizacion a pagado
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <returns></returns>
        ResponseModel ActualizarPago(string DocumentoID);

        /// <summary>
        /// para poder eliminar items
        /// </summary>
        /// <param name="IdCarrito"></param>
        /// <returns></returns>
        ResponseModel Eliminar(int IdCarrito);
    }
}
