using eInfrastructure.Contexts;
using eInfrastructure.Models;
using eInfrastructure.Models.Usuario;
using eInfrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Services
{
    public class UsuarioServices
    {
        private readonly UsuarioRepository repositorio;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuraciones"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpContextAccessor"></param>
        public UsuarioServices(ConfiguracionesModel configuraciones, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            repositorio = new UsuarioRepository(configuraciones, dbContext, httpContextAccessor);
        }

        /// <summary>
        /// login del usuario
        /// </summary>
        /// <param name="_usuario"></param>
        /// <returns></returns>
        public ResponseModel Login(UsuarioLoginModel _usuario)
        {
            return repositorio.Login(_usuario);
        }
    }
}
