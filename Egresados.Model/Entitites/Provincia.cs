using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Model.Entities
{
    [Table("Provincia")]
    public class Provincia
    {
        public Provincia()
        {
          
        }
        #region Propiedades
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Codigo { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Nombre { get; set; }

        public DateTime? FechaAlta { get; set; }

        public DateTime? FechaModificacion { get; set; }

        #endregion

        #region Calculados

        #endregion

        #region Relaciones
       
        #endregion
    }
}
