using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models
{
    public class ConfiguracionesModel
    {
        public string UrlPrincipal { get; set; }

        public string DirectorioAdjuntos { get; set; }

        public int TiempoSesionHora { get; set; }
    }    

    public enum CodEstadoProducto
    {
        Activo = 1,

        Inactivo = 2,

        Borrado = 99,

        Todos = 100
    }
}
