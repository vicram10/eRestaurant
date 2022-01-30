using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eInfrastructure.Entities
{
    public class CategoriaProducto
    {
        [Key]
        public int IdCategoria { get; set; }

        public string DescripcionCategoria { get; set; }

        public int IdUsuarioRegistro { get; set; }

        [ForeignKey("IdUsuarioRegistro")]
        public Usuario UsuarioRegistro { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
