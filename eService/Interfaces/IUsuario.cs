using eInfrastructure.Models;
using eInfrastructure.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Interfaces
{
    public interface IUsuario
    {
        /// <summary>
        /// login del usuario
        /// </summary>
        /// <param name="_usuario"></param>
        /// <returns></returns>
        ResponseModel Login(UsuarioLoginModel _usuario);
    }
}
