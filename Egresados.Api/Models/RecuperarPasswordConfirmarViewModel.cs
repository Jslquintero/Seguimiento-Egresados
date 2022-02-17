using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Egresados.Api.Models
{
    public class RecuperarPasswordConfirmarViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nuevo Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nuevo Password")]
        [Compare("Password", ErrorMessage = "El password y la confirmacion son iguales.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
