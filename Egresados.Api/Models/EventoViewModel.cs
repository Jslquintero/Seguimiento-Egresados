using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Egresados.Model.Entities
{
    public class EventoViewModel
    {

        #region Propiedades
        public int Id { get; set; }

        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEvento { get; set; }
        public DateTime? HoraEvento { get; set; }

        public string Nombre { get; set; }
       
        public string Sala { get; set; }
      
        public Decimal Costo { get; set; }
       
        public string Descripcion { get; set; }

        public int? LugarEventoId { get; set; }
        public int? FacultadId { get; set; }
        #endregion

        #region Calculados

        #endregion

    }
}
