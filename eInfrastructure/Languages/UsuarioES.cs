using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Languages
{
    public class UsuarioES
    {
        public string msgNoUsuarioLogin { get { return "Debe estipular los datos del usuario para poder iniciar sesion"; } } 

        public string msgUsuarioNoExiste { get { return  "Usuario no Existe, verifique!!!"; } }

        public string PasswordIncorrecto { get { return  "Contraseña invalida, verifique!!!"; } }

        public string msgUsuarioNoActivo { get { return  "No puede iniciar sesion, el estado actual de tu usuario es {0}"; } }
    }
}
