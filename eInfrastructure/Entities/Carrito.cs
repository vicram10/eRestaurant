using eInfrastructure.Models.Carrito;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eInfrastructure.Entities
{
    public class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }

        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario UsuarioSolicito { get; set; }

        public DateTime FechaRegistro { get; set; }

        public EstadoCarritoModel Estado { get; set; }
    }
}
