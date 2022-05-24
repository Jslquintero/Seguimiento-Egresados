using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Egresados.Model.Entities
{
    public class BolsaTrabajoViewModel
    {

        #region Propiedades
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        
        public string Empresa { get; set; }

       
        public string VacanteNombre { get; set; }
       
        public string Perfil { get; set; }
      
        public string Telefono { get; set; }
       
        public string Email { get; set; }
      
        public string Observacion { get; set; }
        #endregion

        #region Calculados

        #endregion

    }
}
