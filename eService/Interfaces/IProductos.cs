using eInfrastructure.Models;
using eInfrastructure.Models.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Interfaces
{
    public interface IProductos
    {
        /// <summary>
        /// para poder dar de alta productos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        ResponseModel Alta(ParamProductoAltaModel producto);
    }
}
