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
    }

    public class Amount
    {
        public string currency { get; set; }

        public string value { get; set; }
    }

    public class ValidezPeriodo
    {
        public DateTime start { get; set; }

        public DateTime end { get; set; }
    }
}
