using eInfrastructure.Models;
using eService.Interfaces;
using eWebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWebApi.Controllers
{    
    public class PortalController : Controller
    {
        private readonly ISession session;

        private readonly DatosUsuarioModel datosUsuario;

        public PortalController(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;

            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch {}
        }

        public IActionResult Inicio()
        {
            ViewBag.DatosUsuario = datosUsuario;

            return View();
        }
    }
}
