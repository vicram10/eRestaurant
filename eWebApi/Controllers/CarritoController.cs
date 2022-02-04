using eInfrastructure.Entities;
using eInfrastructure.Languages;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using eService.Interfaces;
using eWebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eWebApi.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly ICarrito apiCarrito;

        private readonly DatosUsuarioModel datosUsuario;

        private readonly ConfiguracionesModel configuraciones;

        private Logger logger = LogManager.GetCurrentClassLogger();

        private readonly Localization languages;

        /// <summary>
        /// constructor principal
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="apiCarrito"></param>
        public CarritoController(IOptions<ConfiguracionesModel> options, IHttpContextAccessor httpContextAccessor, ICarrito apiCarrito)
        {
            this.httpContextAccessor = httpContextAccessor;

            this.apiCarrito = apiCarrito;

            datosUsuario = new DatosUsuarioModel();

            configuraciones = new ConfiguracionesModel();

            ISession session = httpContextAccessor.HttpContext.Session;

            languages = new Localization(httpContextAccessor);

            try
            {
                configuraciones = options.Value;

                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));                
            }
            catch { }
        }

        /// <summary>
        /// para poder visualizar la lista de productos que existen en mi carrito de compra
        /// </summary>
        /// <returns></returns>
        [AuthorizationFilter]
        public IActionResult Index()
        {
            logger.Debug("Carrito_Index");

            List<Carrito> listadoCarrito = apiCarrito.Listar(new ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Pendiente });

            ViewBag.ListadoCarrito = listadoCarrito;

            return View();
        }

        /// <summary>
        /// Para poder preparar el pago en AdamsPay
        /// </summary>
        /// <returns></returns>
        [AuthorizationFilter]
        public IActionResult PrepararPago()
        {
            ResponseModel respuesta = new ResponseModel();

            respuesta = apiCarrito.PrepararPago();

            if (respuesta.CodRespuesta == EstadoRespuesta.Error)
            {
                return RedirectToAction("Inicio", "Error", new { msg = respuesta.MensajeRespuesta });
            }
            else
            {
                AdamsPayResponseModel response = JsonConvert.DeserializeObject<AdamsPayResponseModel>(respuesta.MensajeRespuesta.Split(";")[1]);

                if (response.meta.status == "error")
                {
                    return RedirectToAction("Inicio", "Error", new { msg = response.meta.description });
                }
                else
                {
                    return Redirect(response.debt.payUrl);
                }
            }
        }

        /// <summary>
        /// tus pedidos
        /// </summary>
        /// <returns></returns>
        [AuthorizationFilter]
        public IActionResult Pedidos()
        {
            if (datosUsuario.IdUsuario == 0) { return RedirectToAction("Iniciar", "Usuario"); }

            List<Carrito> listaCarrito = apiCarrito.Listar(new ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Todos });

            logger.Debug($"ListadoCarrito: {JsonConvert.SerializeObject(listaCarrito)}");

            ViewBag.ListaCarrito = listaCarrito;

            return View();
        }

        /// <summary>
        /// Eliminar Carrito
        /// </summary>
        /// <param name="IdCarrito"></param>
        /// <returns></returns>
        [AuthorizationFilter]
        [HttpGet("Carrito/EliminarItem/{IdCarrito}")]
        public JsonResult EliminarItem(int IdCarrito)
        {
            ResponseModel respuesta = new ResponseModel();

            respuesta = apiCarrito.Eliminar(IdCarrito);

            return Json(JsonConvert.SerializeObject(respuesta));
        }

        /// <summary>
        /// MD5::Hash
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        private string MD5Hash(string texto)
        {
            byte[] txtBytes = Encoding.UTF8.GetBytes(texto);

            byte[] hashedBytes = MD5.Create().ComputeHash(txtBytes);

            string resultado = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return resultado;
        }

        /// <summary>
        /// WebHook - Para recibir notificaciones desde AdamsPay
        /// </summary>
        /// <param name="hook"></param>
        /// <returns></returns>
        [HttpPost("Carrito/WebHook")]
        public ActionResult WebHook()
        {
            ResponseModel respuesta = new ResponseModel();

            ///verificamos si realmente es desde adamspay lo que me envian
            ///
            string adamsHash = httpContextAccessor.HttpContext.Request.Headers["x-adams-notify-hash"];

            string _content = "";

            string HeaderType = httpContextAccessor.HttpContext.Request.Headers["Content-Type"];

            string Method = httpContextAccessor.HttpContext.Request.Method;

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                _content = reader.ReadToEnd();
            }

            ///ok primeramente logueamos lo que viene
            ///
            logger.Debug($"WebHookModel: {_content}. Request: {JsonConvert.SerializeObject(httpContextAccessor.HttpContext.Request.Headers)}");

            ///vemos para generar nuestro propio hash
            ///
            string myHash = MD5Hash($"adams{_content}{configuraciones.ApiSecret}");

            ///controlamos
            ///
            if (adamsHash != myHash)
            {
                logger.Debug($"AdamsHash: {adamsHash}, MyHash: {myHash}");

                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = languages.getText("msgNoIgualHash", "Carrito");

                ///firma no valida
                ///
                return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
            }

            ///le agregamos a nuestro modelo
            ///
            WebHookModel hook = new WebHookModel()
            {
                               
            };

            respuesta = apiCarrito.WebHook(hook);

            ///ok hicimos todo correctamente
            ///
            if (respuesta.CodRespuesta == EstadoRespuesta.Ok)
            {
                return Ok(respuesta);
            }

            ///ok le decimos que ignoramos la notificacion que nos enviaron
            ///
            if (respuesta.CodRespuesta == EstadoRespuesta.Ignore)
            {
                return Accepted(respuesta);
            }

            ///ok se rompio todo.. queremos que nos vuelva a avisar la notificacion
            ///
            return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
        }
    }
}
