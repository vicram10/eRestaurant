using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Models.Carrito
{
    public class ParametrosAdamsPayModel
    {
        public Deuda debt { get; set; }
    }

    public class Deuda
    {
        public string docId { get; set; }

        public string label { get; set; }

        public Amount amount { get; set; }

        public ValidezPeriodo validPeriod { get; set; }

        public string payUrl { get; set; }
    }

    public class Amount
    {
        public string currency { get; set; }

        public string value { get; set; }
    }

    public class ValidezPeriodo
    {
        public string start { get; set; }

        public string end { get; set; }
    }
}
