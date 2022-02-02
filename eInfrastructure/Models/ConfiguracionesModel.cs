using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models
{
    public class ConfiguracionesModel
    {
        public bool EsProduccion { get; set; }

        public string UrlPrincipal { get; set; }

        public string DirectorioAdjuntos { get; set; }

        public int TiempoSesionHora { get; set; }

        public string ApiKey { get; set; }

        public string ApiSecret { get; set; }

        public TipoEntorno AdamsPayURL { get; set; }
    }    

    public enum CodEstadoProducto
    {
        Activo = 1,

        Inactivo = 2,

        Borrado = 99,

        Todos = 100
    }

    public class TipoEntorno
    {
        public string Produccion { get; set; }

        public string Desarrollo { get; set; }
    }
}
