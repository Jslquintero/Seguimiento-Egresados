using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Egresados.Model.Entities
{
    public class PaisViewModel
    {

        #region Propiedades
        public int Id { get; set; }      
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        #endregion

        #region Calculados

        #endregion

    }
}
