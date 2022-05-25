using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Model.Entities
{
    [Table("CentroEducativo")]
    public class CentroEducativo
    {
        public CentroEducativo()
        {
        
        }
        #region Propiedades
        public int Id { get; set; }

        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Codigo { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Nombre { get; set; }
        public int? FacultadId { get; set; }
        #endregion

        #region Calculados

        #endregion

        #region Relaciones
        public ICollection<Facultad> Facultad { get; set; }
        #endregion
    }
}
