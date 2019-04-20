using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EKInvAFsemp.Web.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string Nivel { get; set; }

        public string Localidad { get; set; }

    }
}