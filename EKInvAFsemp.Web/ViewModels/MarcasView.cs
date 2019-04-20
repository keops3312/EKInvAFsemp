using EKInvAFsemp.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EKInvAFsemp.Web.ViewModels
{
    public class MarcasView
    {


      
        public int IdMarca { get; set; }

       
        [Display(Name ="Marca")]
        public string Marca { get; set; }

        
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        
        
        [Display(Name = "Registro")]
        public DateTime Alta { get; set; }

        
        [Display(Name = "Activo/Inactivo")]
        public bool ActInac { get; set; }

           
        public string Imagen { get; set; }

        
        [Display(Name = "Tipo")]
        public string TipoMarca { get; set; }

        //para subir la imagen
        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}