using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Egresados.Api.Models
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public string Name { get; set; }
        public int? ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public string Token { get; set; }
        public DateTime? FechaExpiraToken { get; set; }
        public IList<string> Roles { get; set; } 
    }
}
