using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eInfrastructure.Contexts;
using eInfrastructure.Languages;
using eInfrastructure.Models;
using eInfrastructure.Models.Producto;
using Microsoft.AspNetCore.Http;
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
            if (String.IsNullOrEmpty(producto.DescripcionProducto))
            {
                msgError = String.IsNullOrEmpty(msgError) ? languages.getText("msgNoDescripcionProducto", "Producto") : $"{msgError}\r\n{languages.getText("msgNoDescripcionProducto", "Producto")}";
            }

            if (producto.IdCategoriaProducto == 0)
            {
                msgError = String.IsNullOrEmpty(msgError) ? languages.getText("msgNoCategoriaProducto", "Producto") : $"{msgError}\r\n{languages.getText("msgNoCategoriaProducto", "Producto")}";
            }

            if (!String.IsNullOrEmpty(msgError))
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = msgError;

                logger.Error($"Error cuando quisimos dar de alta el producto. Mensaje de Error: {msgError}");

                return respuesta;
            }

            return respuesta;
        }
    }
}