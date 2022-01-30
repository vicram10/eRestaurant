using eInfrastructure.Contexts;
using eInfrastructure.Entities;
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

        /// <summary>
        /// listamos los productos
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <param name="IdEstado"></param>
        /// <returns></returns>
        public List<Producto> Listar(int IdProducto = 0, CodEstadoProducto IdEstado = CodEstadoProducto.Activo)
        {
            return repositorio.Listar(IdProducto, IdEstado);
        }

        /// <summary>
        /// Para poder dar de alta categorias
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public ResponseModel AgregarCategoria(ParamAltaCategoriaModel parametro)
        {
            return repositorio.AgregarCategoria(parametro);
        }

        /// <summary>
        /// Listado de categorias
        /// </summary>
        /// <param name="IdCategoria"></param>
        /// <returns></returns>
        public List<CategoriaProducto> ListarCategoria(int IdCategoria = 0)
        {
            return repositorio.ListarCategoria(IdCategoria);
        }
    }
}
