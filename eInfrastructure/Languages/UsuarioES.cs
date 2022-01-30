using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Languages
{
    public class UsuarioES
    {
        public string lbCedula { get { return "Nro.Cedula"; } }

        public string lbCedulaHelp { get { return "Introduce tu Nro. de Cedula para poder iniciar sesion."; } }

        public string lbPassword { get { return "Contraseña"; } }

        public string lbNombre { get { return "Nombre Usuario"; } }

        public string lbCorreo { get { return "Correo"; } }

        public string lbRegistroUsuario { get { return "Registro de Usuario"; } }

        public string msgNoUsuarioLogin { get { return "Debe estipular los datos del usuario para poder iniciar sesion"; } } 

        public string msgUsuarioNoExiste { get { return  "Usuario no Existe, verifique!!!"; } }

        public string PasswordIncorrecto { get { return  "Contraseña invalida, verifique!!!"; } }

        public string msgUsuarioNoActivo { get { return  "No puede iniciar sesion, el estado actual de tu usuario es {0}"; } }

        public string msgNoPuedeDejarVacio { get { return "No puede dejar vacios los campos!!!!"; } }        
    }
}
