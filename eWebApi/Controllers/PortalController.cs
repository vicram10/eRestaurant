using eInfrastructure.Entities;
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

        private readonly IProductos apiProducto;

        public PortalController(IHttpContextAccessor httpContextAccessor, IProductos apiProducto)
        {
            session = httpContextAccessor.HttpContext.Session;

            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch {}

            this.apiProducto = apiProducto;
        }

        /// <summary>
        /// Inicio
        /// </summary>
        /// <returns></returns>
        public IActionResult Inicio()
        {
            ViewBag.DatosUsuario = datosUsuario;

            List<Producto> ListadoProductos = apiProducto.Listar(IdProducto: 0, IdEstado: CodEstadoProducto.Todos);

            List<CategoriaProducto> ListadoCategoria = apiProducto.ListarCategoria();

            ViewBag.ListadoProductos = ListadoProductos;

            ViewBag.ListadoCategoria = ListadoCategoria;

            return View();
        }
    }
}
