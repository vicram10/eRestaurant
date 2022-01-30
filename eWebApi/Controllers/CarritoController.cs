using eInfrastructure.Entities;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
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
    public class CarritoController : Controller
    {
        private readonly ICarrito apiCarrito;

        private readonly DatosUsuarioModel datosUsuario;

        /// <summary>
        /// constructor principal
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="apiCarrito"></param>
        public CarritoController(IHttpContextAccessor httpContextAccessor, ICarrito apiCarrito)
        {
            this.apiCarrito = apiCarrito;

            datosUsuario = new DatosUsuarioModel();

            ISession session = httpContextAccessor.HttpContext.Session;

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
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

            return View();
        }
    }
}
