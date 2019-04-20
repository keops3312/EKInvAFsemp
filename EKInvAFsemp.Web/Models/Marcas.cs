using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EKInvAFsemp.Web.Models
{
    public class Marcas
    {
        [Key]
        public int IdMarca { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Marca { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Alta { get; set; }

        [Required]
        public bool ActInac { get; set; }

        [Required]
        public string Imagen { get; set; }

        [Required]
        public string TipoMarca { get; set; }


      



    }
}