using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Model.Entities
{
    [Table("AspNetUsers")]
    public class Usuario : IdentityUser
    {
        public Usuario()
        {

        }
        #region Propiedades
        public string Name { get; set; }
        public string LastName { get; set; }

        #endregion

        #region Calculados
        [NotMapped]
        public IList<string> Roles { get; set; }
        #endregion

        #region Relaciones
        public Perfil Perfil { get; set; }
        #endregion
    }
}
