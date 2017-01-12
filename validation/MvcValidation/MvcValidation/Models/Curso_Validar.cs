using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcValidation.Models
{
    public class Curso_Validar
    {
        [DisplayName("Código del curso")]
        public int codigo {get;set;}

         [DisplayName("Nombre del curso")]
         [Required(ErrorMessage = "El nombre del curso es requerido")]
        [StringLength(30,MinimumLength=3,ErrorMessage="No más de 30 caracteres")]
         public string nombre { get; set; }

         [DisplayName("Correo del curso")]
         [Required(ErrorMessage = "Email del curso es requerido")]
         [StringLength(50, ErrorMessage = "No más de 50 caracteres")]
        [EmailAddress(ErrorMessage="Email invalido")]
        public string correo { get; set; }

         [DisplayName("Créditos del curso")]
         [Required(ErrorMessage = "Numero de creditos del curso es requerido")]
        [Range(1,6)]
        public int creditos { get; set; }
    }
}