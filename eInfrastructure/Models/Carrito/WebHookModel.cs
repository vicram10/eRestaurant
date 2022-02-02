using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models.Carrito
{
    public class WebHookModel
    {
        public Notificacion notify { get; set; }

        public Deuda debt { get; set; }
    }

    public class Notificacion
    {
        public string id { get; set; }

        public string type { get; set; }

        public int version { get; set; }

        public string time { get; set; }

        //id de tu comercio
        public string merchant { get; set; }

        //id de tu aplicacion
        public string app { get; set; }

        //ambiente: produccion o test
        public string env { get; set; }
    }
}
