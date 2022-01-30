using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Languages
{
    public class LanguageES
    {
        public string menuInicio { get { return "Portal"; } }

        public string menuIniciarSesion { get { return "Iniciar Sesion"; } }

        public string btnSalir { get { return "Salir"; } }

        public string menuProducto { get { return "Productos"; } }

        ///labels
        ///
        public string lbMensajeErrorHelp { get { return "Error en el Sistema"; } }

        public string lbOpciones { get { return "Opciones"; } }

        public string lbAgregar { get { return "Añadir"; } }

        public string lbBienvenida { get { return "Bienvenido {0}, ahora puede realizar los pedidos."; } }

        ///botones
        ///
        public string btnAgregar { get { return "Agregar"; } }

        public string btnCancelar { get { return "Cancelar"; } }

        public string btnCrear { get { return "Crear"; } }
                
        /// mensajes
        ///
        public string msgRegistroOK { get { return "Registrado con exito!!"; } }

        public string msgNoExisteRegistro { get { return "No existen registros."; } }

        public string msgNoPermiso { get { return "No tiene los permisos necesarios para poder utilizar <b>{0}</b>"; } }

        public string msgDebeIniciarSesion { get { return "Debe iniciar sesion para poder empezar a Solicitar"; } }
    }
}
