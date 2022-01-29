using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models.Usuario
{
    public class UsuarioLoginModel
    {
        public string Cedula { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
