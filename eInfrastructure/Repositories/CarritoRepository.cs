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

        private string apiKey = "tu-api-key";

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

            var carritoExiste = Listar(new ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Pendiente });

            string urlPago = "";

            string documentoID = $"{DateTime.Now.Ticks}Usuario{datosUsuario.IdUsuario.ToString().PadLeft(5, '0')}";

            ///si ya existe un documentoID entonces pisamos
            ///
            if (carritoExiste.Where(pp => !String.IsNullOrEmpty(pp.DocIDAdamsPay)).Count() > 0)
            {
                urlPago = carritoExiste.First().UrlPago;

                documentoID = carritoExiste.First().DocIDAdamsPay;
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

                tabla.UrlPago = urlPago;

                tabla.DocIDAdamsPay = documentoID;

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

            header.Add("apiKey", apiKey);

            header.Add("x-if-exists", "update");

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

            Amount amount = new Amount() 
            {
                currency = "PYG",

                value = totalPagar.ToString()
            };

            DateTime inicio = DateTime.Now;
            
            ValidezPeriodo validPeriod = new ValidezPeriodo() 
            {
                start = inicio.ToString("yyyy-MM-dd'T'hh:mm:ss"),

                end = inicio.AddHours(12).ToString("yyyy-MM-dd'T'hh:mm:ss")
            };

            string documentoID = "";

            if (carrito.Where(pp => !String.IsNullOrEmpty(pp.DocIDAdamsPay)).Count() > 0)
            {
                documentoID = carrito.First().DocIDAdamsPay;
            }

            Deuda deuda = new Deuda
            {
                docId = documentoID,

                label = $"{language.getText("lbAdamsPay", "Carrito")}/{documentoID}",

                amount = amount,

                validPeriod = validPeriod
            };

            ParametrosAdamsPayModel parametros = new ParametrosAdamsPayModel() { debt = deuda };

            ///ok invocamos
            ///
            string resultado = api.Invocar(
                
                header: header, 
                
                metodo: MetodoHttp.Post, 
                
                url: "https://staging.adamspay.com/api/v1/debts", 
                
                controller: "", 
                
                parameter: parametros, 
                
                ref respuesta);

            respuesta.CodRespuesta = EstadoRespuesta.Ok;

            respuesta.MensajeRespuesta = $"[OK];{resultado}";

            AdamsPayResponseModel response = JsonConvert.DeserializeObject<AdamsPayResponseModel>(resultado);

            return respuesta;
        }

        /// <summary>
        /// Verificacion de pago
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <returns></returns>
        public ResponseModel VerificarPago(string DocumentoID)
        {
            ResponseModel respuesta = new ResponseModel();

            api = new ApiConnect();

            Dictionary<string, string> header = new Dictionary<string, string>();

            header.Add("apiKey", apiKey);

            ResponseModel respuestaWS = new ResponseModel();

            ///ok invocamos
            ///
            string resultado = api.Invocar(

                header: header,

                metodo: MetodoHttp.Get,

                url: $"https://staging.adamspay.com/api/v1/debts/{DocumentoID}",

                controller: "",

                parameter: null,

                ref respuestaWS);

            respuesta.CodRespuesta = EstadoRespuesta.Ok;

            respuesta.MensajeRespuesta = $"[OK];{resultado}";

            return respuesta;
        }

        /// <summary>
        /// actualizacion a pagado
        /// </summary>
        /// <param name="DocumentoID"></param>
        /// <returns></returns>
        public ResponseModel ActualizarPago(string DocumentoID)
        {
            ResponseModel respuesta = new ResponseModel();

            var carrito = dbContext.Carrito.AsNoTracking().Where(pp => pp.DocIDAdamsPay == DocumentoID);

            List<Carrito> listaNueva = new List<Carrito>();

            Carrito tabla = new Carrito();

            foreach(Carrito item in carrito)
            {
                tabla = new Carrito();

                tabla = item;

                tabla.Estado = EstadoCarritoModel.Pagado;

                listaNueva.Add(tabla);
            }

            dbContext.Entry(tabla).State = EntityState.Detached;

            dbContext.Entry(tabla).State = EntityState.Modified;

            dbContext.UpdateRange(listaNueva);

            dbContext.SaveChanges();

            int Existencia = Listar(new ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Pendiente }).Count();

            datosUsuario.CantidadCarrito = Existencia;

            session.SetString("datosUsuario", JsonConvert.SerializeObject(datosUsuario));

            return respuesta;
        }

        /// <summary>
        /// para poder eliminar items
        /// </summary>
        /// <param name="IdCarrito"></param>
        /// <returns></returns>
        public ResponseModel Eliminar(int IdCarrito)
        {
            ResponseModel respuesta = new ResponseModel();

            if (IdCarrito == 0)
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = language.getText("msgNoIDBorrado", "Carrito");

                return respuesta;
            }

            Carrito tabla = new Carrito();

            tabla.IdCarrito = IdCarrito;

            dbContext.Entry(tabla).State = EntityState.Deleted;

            dbContext.SaveChanges();

            respuesta.CodRespuesta = EstadoRespuesta.Ok;

            respuesta.MensajeRespuesta = language.getText("msgBorradoOK", "Carrito");

            datosUsuario.CantidadCarrito -= 1;

            if (datosUsuario.CantidadCarrito < 0)
            {
                datosUsuario.CantidadCarrito = 0;
            }

            session.SetString("datosUsuario", JsonConvert.SerializeObject(datosUsuario));

            return respuesta;
        }
    }
}
