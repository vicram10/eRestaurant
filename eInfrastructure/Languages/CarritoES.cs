using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Languages
{
    public class CarritoES
    {
        ///labels
        ///
        public string CarritoTitle { get { return "Ver Carrito"; } }

        public string lbTotalCarrito { get { return "Total a Pagar"; } }

        public string lbFinalizarCompra { get { return "Preparar Pago"; } }

        public string lbCheckOut { get { return "Ir a Ventana de Cobro"; } }

        ///mensajes
        ///
        public string msgNoSeleccionProducto { get { return "Debe especificar un producto para poder!!!"; } }

        public string msgAgregadoOK { get { return "Agreado con exito"; } }
    }
}
