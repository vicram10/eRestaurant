using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eInfrastructure.Entities
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        public string NombreProducto { get; set; }

        public string DescripcionProducto { get; set; }  

        public string ImagenProducto {get; set;}

        public double Precio { get; set; }

        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public CategoriaProducto Categoria { get; set; }

        public int IdEstadoProducto { get; set; }

        [ForeignKey("IdEstadoProducto")]
        public EstadoProducto EstadoProducto { get; set;}

        public int IdUsuarioRegistro { get; set; }

        [ForeignKey("IdUsuarioRegistro")]
        public Usuario UsuarioRegistro { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}