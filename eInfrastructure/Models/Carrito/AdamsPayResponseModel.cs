using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models.Carrito
{
    public class AdamsPayResponseModel
    {
        public Meta meta { get; set; }

        public Deuda debt { get; set; }
    }

    public class Meta
    {
        public string status { get; set; }

        public string description { get; set; }

        public string site { get; set; }

        public string now { get; set; }

        public string op { get; set; }

    }
}
