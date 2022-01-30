using eInfrastructure.Languages;
using eInfrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWebApi.Controllers
{
    public class ErrorController : Controller
    {
        private readonly Localization language;

        private DatosUsuarioModel datosUsuario;

        public ErrorController(IHttpContextAccessor httpContextAccessor)
        {
            language = new Localization(httpContextAccessor);

            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(httpContextAccessor.HttpContext.Session.GetString("datosUsuario"));
            }
            catch { }
        }

        /// <summary>
        /// error accion
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public IActionResult Inicio(string msg, string accion = "")
        {
            string mensaje = "";

            if (!String.IsNullOrEmpty(accion) && msg == "msgNoPermiso")
            {
                mensaje = String.Format(language.getText(msg), accion);
            }
            else
            {
                /*try
                {
                    mensaje = language.getText(msg);
                }
                catch
                {
                    mensaje = msg; //es el mensaje en si ya
                }*/
                mensaje = msg;
            }

            ViewBag.MensajeError = mensaje;

            ViewBag.DatosUsuario = datosUsuario;

            return View();
        }
    }
}
