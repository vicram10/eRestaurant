using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models
{
    public class ResponseModel
    {
        public EstadoRespuesta CodRespuesta { get; set; }

        public string MensajeRespuesta { get; set; }
    }

    public enum EstadoRespuesta
    {
        Ok = 0,

        Error=-1,

        Ignore=202
    }
}
