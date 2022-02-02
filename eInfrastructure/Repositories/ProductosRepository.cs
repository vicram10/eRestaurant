using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eInfrastructure.Contexts;
using eInfrastructure.Entities;
using eInfrastructure.Languages;
using eInfrastructure.Models;
using eInfrastructure.Models.Producto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;

namespace eInfrastructure.Repositories
{
    public class ProductosRepository
    {
        private readonly ConfiguracionesModel configuraciones;

        private readonly ApplicationDbContext dbContext;

        private readonly ISession session;

        private readonly Localization languages;

        private Logger logger = LogManager.GetCurrentClassLogger();

        private readonly DatosUsuarioModel datosUsuario;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuraciones"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpContextAccessor"></param>
        public ProductosRepository(ConfiguracionesModel configuraciones, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor )
        {
            this.configuraciones = configuraciones;

            this.dbContext = dbContext;

            session = httpContextAccessor.HttpContext.Session;

            languages = new Localization(httpContextAccessor);

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch { }
        }

        /// <summary>
        /// para poder dar de alta productos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public ResponseModel Alta(ParamProductoAltaModel producto)
        {
            ResponseModel respuesta = new ResponseModel();

            string msgError = "";

            ///vemos algunas validaciones
            ///
            if (String.IsNullOrEmpty(producto.DescripcionProducto) || String.IsNullOrEmpty(producto.NombreProducto))
            {
                msgError = String.IsNullOrEmpty(msgError) ? languages.getText("msgNoDescripcionProducto", "Producto") : $"{msgError}\r\n{languages.getText("msgNoDescripcionProducto", "Producto")}";
            }

            if (producto.IdCategoriaProducto == 0)
            {
                msgError = String.IsNullOrEmpty(msgError) ? languages.getText("msgNoCategoriaProducto", "Producto") : $"{msgError}\r\n{languages.getText("msgNoCategoriaProducto", "Producto")}";
            }

            if (producto.Precio == 0)
            {
                msgError = String.IsNullOrEmpty(msgError) ? languages.getText("msgNoPrecio", "Producto") : $"{msgError}\r\n{languages.getText("msgNoPrecio", "Producto")}";
            }

            if (!String.IsNullOrEmpty(msgError))
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = msgError;

                logger.Error($"Error cuando quisimos dar de alta el producto. Mensaje de Error: {msgError}");

                return respuesta;
            }

            ///ok no hay nada mas que agregar
            ///
            Producto tabla = new Producto();

            tabla.IdProducto = 0;

            tabla.DescripcionProducto = producto.DescripcionProducto;

            tabla.IdEstadoProducto = (int)CodEstadoProducto.Activo;

            tabla.IdCategoria = producto.IdCategoriaProducto;

            tabla.NombreProducto = producto.NombreProducto;

            tabla.Precio = producto.Precio;

            tabla.FechaRegistro = DateTime.Now;

            tabla.IdUsuarioRegistro = datosUsuario.IdUsuario;

            string v_fileName = "";

            if (producto.ImagenProducto != null)
            {
                foreach (var blobImagen in producto.ImagenProducto)
                {
                    ///hay algo que subir?
                    ///
                    if (blobImagen.Length > 0)
                    {
                        string fileName = blobImagen.FileName;

                        try
                        {

                            v_fileName = $"{DateTime.Now.Ticks}-{fileName}";

                            using (var writer = new FileStream(Path.Combine(configuraciones.DirectorioAdjuntos, v_fileName), FileMode.Create))
                            {

                                blobImagen.CopyTo(writer);

                                respuesta.CodRespuesta = EstadoRespuesta.Ok;
                            }
                        }
                        catch (Exception ex)
                        {

                            string msgExtendido = ex.InnerException != null ? "\r\n" + ex.InnerException.Message.Trim() : "";

                            respuesta.CodRespuesta = EstadoRespuesta.Error;

                            respuesta.MensajeRespuesta = $"Error al subir el archivo: {ex.Message}{msgExtendido}";

                            logger.Error(respuesta.MensajeRespuesta);

                            break;
                        }
                    }
                }
            }

            if (respuesta.CodRespuesta == EstadoRespuesta.Ok)
            {
                tabla.ImagenProducto = String.IsNullOrEmpty(v_fileName) ? "no-imagen" : v_fileName;

                dbContext.Entry(tabla).State = EntityState.Added;

                dbContext.SaveChanges();

                respuesta.MensajeRespuesta = $"{languages.getText("msgRegistroOK")}, {tabla.IdProducto}-{tabla.NombreProducto}";
            }

            return respuesta;
        }

        /// <summary>
        /// listamos los productos
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <param name="IdEstado"></param>
        /// <returns></returns>
        public List<Producto> Listar(int IdProducto = 0, CodEstadoProducto IdEstado = CodEstadoProducto.Activo)
        {
            List<Producto> listar = new List<Producto>();

            listar = dbContext.Productos.Include(pp => pp.EstadoProducto)
                .Include(pp => pp.Categoria)
                .Where(xx => xx.IdProducto == IdProducto || IdProducto == 0).ToList();

            if (IdEstado != CodEstadoProducto.Todos)
            {
                int codigoEstado = (int)IdEstado;

                listar = listar.Where(pp => pp.IdEstadoProducto == codigoEstado).ToList();
            }

            return listar;
        }

        /// <summary>
        /// Para poder dar de alta categorias
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public ResponseModel AgregarCategoria(ParamAltaCategoriaModel parametro)
        {
            ResponseModel respuesta = new ResponseModel();

            if (String.IsNullOrEmpty(parametro.DescripcionCategoria))
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = languages.getText("msgNoCategoriaProducto", "Producto");

                return respuesta;
            }

            CategoriaProducto tabla = new CategoriaProducto();

            tabla.IdCategoria = 0;

            tabla.DescripcionCategoria = parametro.DescripcionCategoria;

            tabla.IdUsuarioRegistro = datosUsuario.IdUsuario;

            tabla.FechaRegistro = DateTime.Now;

            dbContext.Entry(tabla).State = EntityState.Added;

            dbContext.SaveChanges();

            respuesta.CodRespuesta = EstadoRespuesta.Ok;

            respuesta.MensajeRespuesta = $"{tabla.IdCategoria};{tabla.DescripcionCategoria}";

            return respuesta;
        }

        /// <summary>
        /// Listado de categorias
        /// </summary>
        /// <param name="IdCategoria"></param>
        /// <returns></returns>
        public List<CategoriaProducto> ListarCategoria(int IdCategoria = 0)
        {
            List<CategoriaProducto> listado = new List<CategoriaProducto>();

            listado = dbContext.CategoriaProducto.Where(pp => pp.IdCategoria == IdCategoria || IdCategoria == 0).ToList();

            return listado;
        }
    }
}