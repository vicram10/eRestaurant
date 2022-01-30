using eInfrastructure.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWebApi.Controllers
{
    public class ErrorController : Controller
    {
        private readonly Localization language;

        public ErrorController(IHttpContextAccessor httpContextAccessor)
        {
            language = new Localization(httpContextAccessor);
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
                try
                {
                    mensaje = language.getText(msg);
                }
                catch
                {
                    mensaje = msg; //es el mensaje en si ya
                }
            }

            ViewBag.MensajeError = mensaje;

            return View();
        }
    }
}
