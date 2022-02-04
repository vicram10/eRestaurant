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

        public string lbAdamsPay { get { return "Compra Carrito"; } }

        public string lbTusPedidos { get { return "Tus Pedidos"; } }

        public string lbEstado { get { return "Estado del Pedido"; } }

        public string lbDocID { get { return "Codigo Adamspay"; } }

        ///mensajes
        ///
        public string msgNoSeleccionProducto { get { return "Debe especificar un producto para poder!!!"; } }

        public string msgAgregadoOK { get { return "Agreado con exito"; } }

        public string msgNoOkTotalPagar { get { return "Ocurrio un problema la totalidad de la deuda."; } }

        public string msgNoIDBorrado { get { return "Debe colocar una id para poder borrar!!!"; } }

        public string msgBorradoOK { get { return "Borrado con exito!!"; } }

        public string msgNoIgualHash { get { return "No se puede procesar, no corresponde la firma enviada."; } }
    }
}
