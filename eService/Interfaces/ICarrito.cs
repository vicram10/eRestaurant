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
        /// actualizacion estado carrito
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <param name="estadoCarrito"></param>
        /// <returns></returns>
        ResponseModel ActualizarCarrito(string DocumentoID, EstadoCarritoModel estadoCarrito, string urlPago);

        /// <summary>
        /// para poder eliminar items
        /// </summary>
        /// <param name="IdCarrito"></param>
        /// <returns></returns>
        ResponseModel Eliminar(int IdCarrito);

        /// <summary>
        /// Para poder recibir notificaciones desde AdamsPay
        /// </summary>
        /// <param name="hook"></param>
        /// <returns></returns>
        ResponseModel WebHook(WebHookModel hook);
    }
}
