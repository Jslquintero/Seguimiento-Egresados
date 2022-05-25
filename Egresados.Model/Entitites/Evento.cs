using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Model.Entities
{
    [Table("Evento")]
    public class Evento
    {
        public Evento()
        {
            
        }
        #region Propiedades
        public int Id { get; set; }

        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEvento { get; set; }
        public DateTime? HoraEvento { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Sala { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Costo { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Descripcion { get; set; }

        public int? LugarEventoId { get; set; }
        public int? FacultadId { get; set; }

        #endregion

        #region Calculados

        [NotMapped]

        public string FechaString
        {
            get
            {
                return FechaEvento.Value.ToShortDateString();
            }
        }

        public string HoraString
        {
            get
            {
                return HoraEvento.Value.ToString("hh:mm tt");
            }
        }

        #endregion

        #region Relaciones
        public LugarEvento LugarEvento { get; set; }
        public Facultad Facultad { get; set; }
        #endregion
    }
}
