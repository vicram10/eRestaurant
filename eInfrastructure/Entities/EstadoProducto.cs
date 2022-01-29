using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace eInfrastructure.Entities
{
    public class EstadoProducto
    {
        [Key]
        public int IdEstadoProducto { get; set; }

        public string DescripcionProducto { get; set; }
    }
}