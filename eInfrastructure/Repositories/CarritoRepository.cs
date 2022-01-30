using eInfrastructure.Contexts;
using eInfrastructure.Models;
using eInfrastructure.Models.Carrito;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Repositories
{
    public class CarritoRepository
    {
        private readonly ConfiguracionesModel configuraciones;

        private readonly ApplicationDbContext dbContext;

        private readonly ISession session;

        private readonly DatosUsuarioModel datosUsuario;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuraciones"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpContextAccessor"></param>
        public CarritoRepository(ConfiguracionesModel configuraciones, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.configuraciones = configuraciones;

            this.dbContext = dbContext;

            session = httpContextAccessor.HttpContext.Session;

            datosUsuario = new DatosUsuarioModel();

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(session.GetString("datosUsuario"));
            }
            catch { }
        }

        /// <summary>
        /// Agregar al Carrito
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public ResponseModel Agregar(ParamAgregarCarritoModel parametro )
        {
            ResponseModel respuesta = new ResponseModel();


            return respuesta;
        }
    }
}
