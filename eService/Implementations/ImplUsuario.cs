using eInfrastructure.Contexts;
using eInfrastructure.Models;
using eInfrastructure.Models.Usuario;
using eService.Interfaces;
using eService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Implementations
{
    public class ImplUsuario : IUsuario
    {
        private readonly UsuarioServices servicio;

        /// <summary>
        /// constructor principal
        /// </summary>
        /// <param name="options"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpConcextAccessor"></param>
        public ImplUsuario(IOptions<ConfiguracionesModel> options, ApplicationDbContext dbContext, IHttpContextAccessor httpConcextAccessor)
        {
            servicio = new UsuarioServices(options.Value, dbContext, httpConcextAccessor);
        }

        /// <summary>
        /// login del usuario
        /// </summary>
        /// <param name="_usuario"></param>
        /// <returns></returns>
        public ResponseModel Login(UsuarioLoginModel _usuario)
        {
            return servicio.Login(_usuario);
        }
    }
}
