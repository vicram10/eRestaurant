using eInfrastructure.Entities;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using eInfrastructure.Models.Usuario;
using eService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWebApi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario apiUsuario;

        private readonly ISession session;

        private readonly ICarrito apiCarrito;

        private DatosUsuarioModel datosUsuario;

        /// <summary>
        /// constructor principal
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="apiUsuario"></param>
        public UsuarioController(IHttpContextAccessor httpContextAccessor, IUsuario apiUsuario, ICarrito apiCarrito)
        {
            this.apiUsuario = apiUsuario;

            session = httpContextAccessor.HttpContext.Session;

            this.apiCarrito = apiCarrito;
        }

        /// <summary>
        /// Iniciar Sesion
        /// </summary>
        /// <returns></returns>
        public IActionResult Iniciar()
        {
            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch{}

            if (datosUsuario.IdUsuario != 0)
            {
                return RedirectToAction("Inicio", "Portal");
            }

            ViewBag.DatosUsuario = datosUsuario;

            return View();
        }

        /// <summary>
        /// Iniciamos la sesion en el sistema
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult IniciarSesion([FromForm] UsuarioLoginModel usuario)
        {
            ResponseModel respuesta = new ResponseModel();

            respuesta = apiUsuario.Login(usuario);

            if (respuesta.CodRespuesta == EstadoRespuesta.Ok)
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));

                ///buscamos si tiene algun carrito cargado...
                ///
                List<Carrito> Carrito = apiCarrito.Listar(new eInfrastructure.Models.Carrito.ParamFiltroBusquedaCarritoModel { IdUsuario = datosUsuario.IdUsuario, EstadoCarrito = EstadoCarritoModel.Pendiente });

                if (Carrito.Count > 0)
                {
                    datosUsuario.CantidadCarrito = Carrito.Count;

                    ///actualizamos la session del usuario para comenzar con la cantidad que tiene
                    ///
                    session.SetString("datosUsuario", JsonConvert.SerializeObject(datosUsuario));
                }
            }

            return Json(JsonConvert.SerializeObject(respuesta));
        }

        /// <summary>
        /// Cerramos la sesion del usuario
        /// </summary>
        /// <returns></returns>
        public IActionResult Salir()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Inicio", "Portal");
        }

        /// <summary>
        /// Registro de Usuario
        /// </summary>
        /// <returns></returns>
        public IActionResult Registro()
        {
            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch { }

            if (datosUsuario.IdUsuario != 0)
            {
                return RedirectToAction("Inicio", "Portal");
            }

            ViewBag.DatosUsuario = datosUsuario;

            return View();
        }

        /// <summary>
        /// para poder dar de alta el usuario
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Crear([FromForm] ParamUsuarioRegistroModel param)
        {
            ResponseModel respuesta = new ResponseModel();

            respuesta = apiUsuario.Registrar(param);

            return Json(JsonConvert.SerializeObject(respuesta));
        }
    }
}
