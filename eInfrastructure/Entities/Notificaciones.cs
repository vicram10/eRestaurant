using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eInfrastructure.Entities
{
    public class Notificaciones
    {
        [Key]
        public int Id { get; set; }
                
        public string IdNotificacion { get; set; }

        public string TipoNotificacion { get; set; }

        public int Version { get; set; }

        public DateTime FechaNotificacion { get; set; }

        public string IdComercio { get; set; }

        public string IdAplicacion { get; set; }

        public string Ambiente { get; set; }

    }
}
