using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models.Producto
{
    public class ParamProductoAltaModel
    {
        public string NombreProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public double Precio { get; set; }

        public int IdCategoriaProducto { get; set; }

        public List<IFormFile> ImagenProducto { get; set; }
    }
}
