using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models.Carrito
{
    public class ParamFiltroBusquedaCarritoModel
    {
        public int IdUsuario { get; set; }

        public string DocId { get; set; }

        public EstadoCarritoModel EstadoCarrito { get; set; }
    }
}
