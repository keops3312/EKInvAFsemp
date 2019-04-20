using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EKInvAFsemp.Web.Models
{
    public class Tipos
    {
        [Key]
        public int IdTipos { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Tipo { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Descripcion { get; set; }

        public DateTime Alta { get; set; }

        public string Operador { get; set; }


        public string imagen { get; set; }

        public bool ActInac { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string NombreTipo { get; set; }

      
    }
}