using eInfrastructure.Entities;
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

        /// <summary>
        /// listamos los productos
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <param name="IdEstado"></param>
        /// <returns></returns>
        List<Producto> Listar(int IdProducto = 0, CodEstadoProducto IdEstado = CodEstadoProducto.Activo);

        /// <summary>
        /// Para poder dar de alta categorias
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        ResponseModel AgregarCategoria(ParamAltaCategoriaModel parametro);

        /// <summary>
        /// Listado de categorias
        /// </summary>
        /// <param name="IdCategoria"></param>
        /// <returns></returns>
        List<CategoriaProducto> ListarCategoria(int IdCategoria = 0);
    }
}
