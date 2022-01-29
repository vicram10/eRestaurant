using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eInfrastructure.Entities
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }

        public string DescripcionEstado { get; set; }
    }
}
