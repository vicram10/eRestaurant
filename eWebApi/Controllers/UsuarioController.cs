using eInfrastructure.Models;
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

        /// <summary>
        /// constructor principal
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="apiUsuario"></param>
        public UsuarioController(IHttpContextAccessor httpContextAccessor, IUsuario apiUsuario)
        {
            this.apiUsuario = apiUsuario;

            session = httpContextAccessor.HttpContext.Session;
        }

        /// <summary>
        /// Iniciar Sesion
        /// </summary>
        /// <returns></returns>
        public IActionResult Iniciar()
        {
            DatosUsuarioModel datosUsuario = new DatosUsuarioModel();

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

        [HttpPost]
        public JsonResult IniciarSesion([FromForm] UsuarioLoginModel usuario)
        {
            ResponseModel respuesta = new ResponseModel();

            respuesta = apiUsuario.Login(usuario);

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
    }
}
