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
    }
}
