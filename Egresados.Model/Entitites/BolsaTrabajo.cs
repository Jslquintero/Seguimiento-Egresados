using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Model.Entities
{
    [Table("BolsaTrabajo")]
    public class BolsaTrabajo
    {
        public BolsaTrabajo()
        {
         
        }
        #region Propiedades
        public int Id { get; set; }

        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaModificacion { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Empresa { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string VacanteNombre { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Perfil { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Telefono { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Observacion { get; set; }

        #endregion

        #region Calculados

        #endregion

        #region Relaciones

        #endregion
    }
}
