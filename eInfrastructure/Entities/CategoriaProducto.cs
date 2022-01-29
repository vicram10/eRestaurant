using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eInfrastructure.Entities
{
    public class CategoriaProducto
    {
        [Key]
        public int IdCategoria { get; set; }

        public string DescripcionCategoria { get; set; }
    }
}
