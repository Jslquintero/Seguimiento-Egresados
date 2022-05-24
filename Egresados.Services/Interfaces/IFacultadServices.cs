using Egresados.Model.Entities;
using Egresados.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services.Interfaces
{
    public interface IFacultadServices : IRepositorio<Facultad>
    {
        Task<Facultad> Save(Facultad entidad);
        Task<Facultad> Delete(int id);
    }
}
