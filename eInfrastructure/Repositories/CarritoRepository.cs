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
using System.Linq;
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

        private ApiConnect api;

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

                datosUsuario.CantidadCarrito++;

                session.SetString("datosUsuario", JsonConvert.SerializeObject(datosUsuario));

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

        /// <summary>
        /// listamos el carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public List<Carrito> Listar(ParamFiltroBusquedaCarritoModel parametro)
        {
            List<Carrito> listado = new List<Carrito>();

            listado = dbContext.Carrito.Include(ii => ii.Producto)
                                       .Include(ii => ii.UsuarioSolicito)
                                       .Where(pp => pp.IdUsuario == parametro.IdUsuario || parametro.IdUsuario == 0)
                                       .ToList();

            if (parametro.EstadoCarrito != EstadoCarritoModel.Todos)
            {
                listado = listado.Where(ww => ww.Estado == parametro.EstadoCarrito).ToList();
            }

            return listado;
        }     

        /// <summary>
        /// para poder preparar el pago en adamspay
        /// </summary>
        /// <returns></returns>
        public ResponseModel PrepararPago()
        {
            ResponseModel respuesta = new ResponseModel();

            api = new ApiConnect();

            Dictionary<string, string> header = new Dictionary<string, string>();

            header.Add("apiKey", "ap-6462542fb0fd35f6b18aea5b");

            ///traemos la deuda total del cliente
            ///
            var carrito = Listar(new ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Pendiente });

            double totalPagar = 0;

            if (carrito.Count > 0)
            {
                totalPagar = carrito.Select(pp => pp.Producto.Precio).Sum();
            }
            else
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = language.getText("msgNoOkTotalPagar", "Carrito");

                return respuesta;
            }

            string docID = $"{DateTime.Now.Ticks}Usuario{datosUsuario.IdUsuario.ToString().PadLeft(5, '0')}";

            Amount amount = new Amount() 
            {
                currency = "PYG",

                value = totalPagar.ToString()
            };

            ValidezPeriodo validPeriod = new ValidezPeriodo() 
            {
                start = DateTime.UtcNow,

                end = DateTime.UtcNow.AddHours(12)
            };

            ParametrosAdamsPayModel parametros = new ParametrosAdamsPayModel() 
            { 
                docId = docID,

                label = $"{language.getText("lbAdamsPay", "Carrito")}/{docID}",

                amount = amount,

                validPeriod = validPeriod
            };
            
            
            ///ok invocamos
            ///
            string resultado = api.Invocar(
                
                header: header, 
                
                metodo: MetodoHttp.Post, 
                
                url: "https://staging.adamspay.com/api/v1/debts", 
                
                controller: "", 
                
                parameter: parametros, 
                
                ref respuesta);

            return respuesta;
        }
    }
}
