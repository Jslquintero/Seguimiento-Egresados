using Egresados.Model.Entities;
using Egresados.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services.Interfaces
{
    public interface IEventoServices : IRepositorio<Evento>
    {
        Task<Evento> Save(Evento entidad);
        Task<Evento> Delete(int id);
    }
}
