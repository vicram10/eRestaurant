using eInfrastructure.Entities;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using eService.Interfaces;
using eWebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// constructor principal
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="apiCarrito"></param>
        public CarritoController(IHttpContextAccessor httpContextAccessor, ICarrito apiCarrito)
        {
            this.httpContextAccessor = httpContextAccessor;

            this.apiCarrito = apiCarrito;

            datosUsuario = new DatosUsuarioModel();

            configuraciones = new ConfiguracionesModel();

            ISession session = httpContextAccessor.HttpContext.Session;

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));

                configuraciones = JsonConvert.DeserializeObject<ConfiguracionesModel>(session.GetString("Configuraciones"));
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
            logger.Error("Carrito_Index");

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
        /// WebHook - Para recibir notificaciones desde AdamsPay
        /// </summary>
        /// <param name="hook"></param>
        /// <returns></returns>
        [HttpPost("Carrito/WebHook")]
        public ActionResult WebHook([FromBody] JsonElement json)
        {
            ///ok primeramente logueamos lo que viene
            ///
            logger.Debug($"WebHookModel: {json}. Request: {JsonConvert.SerializeObject(httpContextAccessor.HttpContext.Request.Headers)}");

            ResponseModel respuesta = new ResponseModel();

            WebHookModel hook = new WebHookModel();

            respuesta = apiCarrito.WebHook(hook);

            ///ok hicimos todo correctamente
            ///
            if (respuesta.CodRespuesta == EstadoRespuesta.Ok)
            {
                return Ok(JsonConvert.SerializeObject(respuesta));
            }

            ///ok le decimos que ignoramos la notificacion que nos enviaron
            ///
            if (respuesta.CodRespuesta == EstadoRespuesta.Ignore)
            {
                return Accepted(JsonConvert.SerializeObject(respuesta));
            }

            ///ok se rompio todo.. queremos que nos vuelva a avisar la notificacion
            ///
            return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(respuesta));
        }
    }
}
