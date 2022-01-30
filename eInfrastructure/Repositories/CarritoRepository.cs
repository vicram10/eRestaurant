using eInfrastructure.Contexts;
using eInfrastructure.Entities;
using eInfrastructure.Languages;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Repositories
{
    public class CarritoRepository
    {
        private readonly ConfiguracionesModel configuraciones;

        private readonly ApplicationDbContext dbContext;

        private readonly ISession session;

        private readonly DatosUsuarioModel datosUsuario;

        private readonly Localization language;

        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuraciones"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpContextAccessor"></param>
        public CarritoRepository(ConfiguracionesModel configuraciones, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.configuraciones = configuraciones;

            this.dbContext = dbContext;

            session = httpContextAccessor.HttpContext.Session;

            language = new Localization(httpContextAccessor);

            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch { }
        }

        /// <summary>
        /// Agregar al Carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public ResponseModel Agregar(ParamAgregarCarritoModel parametro )
        {
            ResponseModel respuesta = new ResponseModel();

            ///hacemos alguna validacion
            ///
            if (parametro.IdProducto == 0)
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = language.getText("msgNoSeleccionProducto", "Carrito");

                return respuesta;
            }

            ///ok hacemos el insert en el carrito
            ///

            try
            {
                
                Carrito tabla = new Carrito();

                tabla.IdCarrito = 0;

                tabla.IdProducto = parametro.IdProducto;

                tabla.IdUsuario = datosUsuario.IdUsuario;

                tabla.FechaRegistro = DateTime.Now;

                tabla.Estado = EstadoCarritoModel.Pendiente;

                dbContext.Entry(tabla).State = EntityState.Added;

                dbContext.SaveChanges();

                respuesta.CodRespuesta = EstadoRespuesta.Ok;

                respuesta.MensajeRespuesta = language.getText("msgAgregadoOK", "Carrito");

            }
            catch(Exception ex)
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = $"Error cuando quisimos realizar el registro en el Carrito.\r\nError: {ex.Message}";

                logger.Error(respuesta.MensajeRespuesta);                
            }

            ///ok termino, retornamos algun valor
            ///
            return respuesta;
        }
    }
}
