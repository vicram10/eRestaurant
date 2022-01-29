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
    [AuthorizationFilter]
    public class ProductoController : Controller
    {
        private readonly ISession session;

        private readonly IProductos apiProducto;

        private readonly DatosUsuarioModel datosUsuario;

        public ProductoController(IHttpContextAccessor httpContextAccessor, IProductos apiProducto)
        {
            session = httpContextAccessor.HttpContext.Session;

            this.apiProducto = apiProducto;

            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch { }
        }

        public IActionResult Index()
        {
            if (datosUsuario.IdUsuario == 0) { return RedirectToAction("Iniciar", "Usuario"); }

            return View();
        }
    }
}
