using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Languages
{
    public class ProductoES
    {
        ///labels
        ///
        public string lbNombreProducto { get { return "Nombre Producto"; } }

        public string colProducto { get { return "Descripcion Producto"; } }

        public string colImagen { get { return "Imagen Producto"; } }
        
        public string lbAltaProducto { get { return "Alta de Producto"; } }

        public string lbAltaCategoria { get { return "Alta de Categoria del Producto"; } }

        public string lbCategoria { get { return "Categoria del Producto"; } }

        public string lbPrecio { get { return "Precio del Producto"; } }

        /// mensajes
        /// 
        public string msgNoDescripcionProducto { get { return "No puede dejar vacio el campo Descripcion/Nombre del Producto.!!!"; } }

        public string msgNoCategoriaProducto { get { return "No puede dejar vacio el campo Categoria del Producto.!!!"; } }

        public string msgNoPrecio { get { return "No puede dejar vacio o cero el precio del producto.!!!"; } }
    }
}
