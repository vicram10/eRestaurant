using eInfrastructure.Entities;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using eInfrastructure.Models.Producto;
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
    public class ProductoController : Controller
    {
        private readonly ISession session;
        
        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly IProductos apiProducto;
        
        private readonly ICarrito apiCarrito;
        
        private readonly DatosUsuarioModel datosUsuario;

        /// <summary>
        /// constructor principal
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="apiProducto"></param>
        public ProductoController(IHttpContextAccessor httpContextAccessor, IProductos apiProducto, ICarrito apiCarrito)
        {
            session = httpContextAccessor.HttpContext.Session;
                        
            this.httpContextAccessor = httpContextAccessor;
            
            this.apiProducto = apiProducto;

            this.apiCarrito = apiCarrito;
            
            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch { }
        }

        /// <summary>
        /// pagina de inicio para los productos
        /// </summary>
        /// <returns></returns>
        [AuthorizationFilter]
        public IActionResult Index()
        {
            if (datosUsuario.IdUsuario == 0) { return RedirectToAction("Iniciar", "Usuario"); }

            List<Producto> ListadoProductos = apiProducto.Listar(IdProducto: 0, IdEstado: CodEstadoProducto.Todos);

            ViewBag.ListadoProductos = ListadoProductos;

            string valorQuery = "";

            string codigoMensaje = "";

            string MensajeFinal = "";

            if (httpContextAccessor.HttpContext.Request.QueryString.HasValue)
            {
                try
                {
                    valorQuery = httpContextAccessor.HttpContext.Request.Query["msg"];

                    codigoMensaje = valorQuery.Split(";")[0];

                    MensajeFinal = valorQuery.Split(";")[1];
                }
                catch { }
            }

            ViewBag.CodigoMensaje = codigoMensaje;

            ViewBag.MensajeAlta = MensajeFinal;

            List<CategoriaProducto> ListadoCategoria = apiProducto.ListarCategoria();

            ViewBag.ListadoCategoria = ListadoCategoria;

            return View();
        }

        /// <summary>
        /// formulario de alta de productos
        /// </summary>
        /// <returns></returns>
        [AuthorizationFilter]
        public IActionResult Alta()
        {
            if (datosUsuario.IdUsuario == 0) { return RedirectToAction("Iniciar", "Usuario"); }

            List<CategoriaProducto> ListadoCategorias = new List<CategoriaProducto>();

            ListadoCategorias = apiProducto.ListarCategoria(IdCategoria: 0);

            ViewBag.Categorias = ListadoCategorias;

            return View();
        }

        /// <summary>
        /// Damos de alta los productos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        [AuthorizationFilter]
        [HttpPost]
        public IActionResult Registrar([FromForm] ParamProductoAltaModel parametro)
        {
            ResponseModel respuesta = apiProducto.Alta(parametro);

            if (respuesta.CodRespuesta == EstadoRespuesta.Error)
            {
                return RedirectToAction("Inicio", "Error", new { msg = respuesta.MensajeRespuesta });
            }
            else
            {
                return RedirectToAction("Index", "Producto", new { msg = $"OK;{respuesta.MensajeRespuesta}" });
            }
        }

        /// <summary>
        /// agregar categoria para los productos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        [AuthorizationFilter]
        [HttpPost]
        public JsonResult AgregarCategoria([FromForm] ParamAltaCategoriaModel parametro)
        {
            ResponseModel respuesta = apiProducto.AgregarCategoria(parametro);

            return Json(JsonConvert.SerializeObject(respuesta));
        }

        /// <summary>
        /// Para poder agregar al carrito de compras
        /// </summary>
        /// <param name="carrito"></param>
        /// <returns></returns>
        [AuthorizationFilter]
        [HttpGet("Producto/AgregarCarrito/{IdProducto}")]
        public JsonResult AgregarCarrito(int IdProducto)
        {
            ParamAgregarCarritoModel carrito = new ParamAgregarCarritoModel() { IdProducto = IdProducto };

            ResponseModel respuesta = apiCarrito.Agregar(carrito);

            return Json(JsonConvert.SerializeObject(respuesta));
        }
    }
}
