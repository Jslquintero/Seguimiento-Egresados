using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Egresados.Api.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
