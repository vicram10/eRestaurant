using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eInfrastructure.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [MinLength(8)]
        public string Contraseña { get; set; }

        [Required]
        public string Correo { get; set; }

        public int IdUsuarioRegistro { get; set; }

        public DateTime FechaRegistro { get; set; }

        [Required]
        [MaxLength(3)]
        public string IdiomaElegido { get; set; }

        [Required]
        public bool esAdministrador { get; set; }

        [Required]
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
    }
}
