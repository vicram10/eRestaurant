using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models
{
    public class DatosUsuarioModel
    {
        public int IdUsuario { get; set; }

        public string NroCedula { get; set; }

        public string NombreUsuario { get; set; }

        public string Idioma { get; set; }

        public string Correo { get; set; }

        public string Imagen { get; set; }

        public bool esAdministrador { get; set; }
        
        public int CantidadCarrito { get; set; }

        public int IdEstado { get; set; }

        public string Estado { get; set; }

    }

}
