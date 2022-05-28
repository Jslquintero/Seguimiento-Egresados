using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Egresados.Model.Entities
{
    public class Perfil
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        #region Propiedades
        public string Id { get; set; }
        public string Biografia { get; set; }
        public string Direccion { get; set; }
        public string Empresa { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string Genero { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string Telefono { get; set; }
        #endregion
        public int? ProvinciaId { get; set; }
        public int? FacultadId { get; set; }
        public string UsuarioId { get; set; }
        #region Calculados
        
        [NotMapped]

        public string FechaString
        {
            get
            {
                return FechaNacimiento.HasValue ? FechaNacimiento.Value.ToString("dd/MM/yyyy") : "";
            }
        }

        #endregion

        #region Relaciones
        public ICollection<Usuario> Usuario { get; set; }
        public ICollection<Provincia> Provincia { get; set; }
        public ICollection<Facultad> Facultad { get; set; }
        #endregion
    }
}
