using Egresados.Model.Entities;
using Egresados.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services.Interfaces
{
    public interface ILugarEventoServices : IRepositorio<LugarEvento>
    {
        Task<LugarEvento> Save(LugarEvento entidad);
        Task<LugarEvento> Delete(int id);
    }
}
