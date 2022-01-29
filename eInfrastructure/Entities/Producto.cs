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

        public string DescripcionProducto { get; set; }  

        public string ImagenProducto {get; set;}

        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public CategoriaProducto Categoria { get; set; }

        public int IdEstadoProducto { get; set; }

        [ForeignKey("IdEstadoProducto")]
        public EstadoProducto EstadoProducto { get; set;}
    }
}