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
using System.Threading.Tasks;

namespace eWebApi.Controllers
{
    [AuthorizationFilter]
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
        public IActionResult Index()
        {
            List<Carrito> listadoCarrito = apiCarrito.Listar(new ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Pendiente });

            ViewBag.ListadoCarrito = listadoCarrito;

            string queryString = "";

            string documentoID = "";

            if (httpContextAccessor.HttpContext.Request.QueryString.HasValue)
            {
                queryString = httpContextAccessor.HttpContext.Request.QueryString.Value;

                if (queryString.Contains("doc_id"))
                {
                    documentoID = httpContextAccessor.HttpContext.Request.Query["doc_id"];
                }
            }

            if (!String.IsNullOrEmpty(documentoID))
            {
                return Redirect($"{configuraciones.UrlPrincipal}/Carrito/VerificarPago/{documentoID}");
            }

            return View();
        }

        /// <summary>
        /// Para poder preparar el pago en AdamsPay
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PrepararPago()
        {
            ResponseModel respuesta = new ResponseModel();

            var carrito = apiCarrito.Listar(new ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Pendiente });

            string documentoID = carrito.FirstOrDefault().DocIDAdamsPay;

            if (!String.IsNullOrEmpty(documentoID))
            {
                respuesta = new ResponseModel();

                respuesta = apiCarrito.VerificarPago(documentoID);

                if (respuesta.CodRespuesta == EstadoRespuesta.Ok)
                {
                    AdamsPayResponseModel response = JsonConvert.DeserializeObject<AdamsPayResponseModel>(respuesta.MensajeRespuesta.Split(";")[1]);

                    if (response != null)
                    {
                        if (response.debt.payStatus.status == "paid")
                        {
                            respuesta = apiCarrito.ActualizarPago(response.debt.docId);

                            return RedirectToAction("Inicio", "Portal");
                        }
                    }
                }

            }

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
        /// Para poder ver si ya se pago un documento
        /// </summary>
        /// <param name="IdPago"></param>
        /// <returns></returns>
        [HttpGet("Carrito/VerificarPago/{IdPago}")]
        public IActionResult VerificarPago(string IdPago)
        {
            ResponseModel respuesta = new ResponseModel();

            respuesta = apiCarrito.VerificarPago(IdPago);

            if (respuesta.CodRespuesta == EstadoRespuesta.Ok)
            {
                AdamsPayResponseModel response = JsonConvert.DeserializeObject<AdamsPayResponseModel>(respuesta.MensajeRespuesta.Split(";")[1]);

                if (response.debt.payStatus.status == "paid")
                {
                    respuesta = apiCarrito.ActualizarPago(IdPago);

                    return RedirectToAction("Inicio", "Portal");
                }
            }

            return RedirectToAction("Index", "Carrito");
        }

        /// <summary>
        /// tus pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Pedidos()
        {
            if (datosUsuario.IdUsuario == 0) { return RedirectToAction("Iniciar", "Usuario"); }

            List<Carrito> listaCarrito = apiCarrito.Listar(new ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Todos });

            ///revisamos en adamspay los que estan con estado 1
            ///
            foreach(Carrito item in listaCarrito.Where(pp => pp.Estado == EstadoCarritoModel.Pendiente))
            {
                ResponseModel respuesta = new ResponseModel();

                respuesta = apiCarrito.VerificarPago(item.DocIDAdamsPay);

                if (respuesta.CodRespuesta == EstadoRespuesta.Error)
                {
                    logger.Error($"Error cuando quisimos revisar el pago de un docID ({item.DocIDAdamsPay}).\r\n{respuesta.MensajeRespuesta}");
                }
                else
                {
                    AdamsPayResponseModel response = JsonConvert.DeserializeObject<AdamsPayResponseModel>(respuesta.MensajeRespuesta.Split(";")[1]);

                    if (response != null)
                    {
                        if (response.debt.payStatus.status == "paid")
                        {
                            respuesta = new ResponseModel();
                            respuesta = apiCarrito.ActualizarPago(item.DocIDAdamsPay);
                        }
                    }
                }
            }

            ViewBag.ListaCarrito = listaCarrito;

            return View();
        }
    }
}
