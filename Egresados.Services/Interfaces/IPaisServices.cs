using Egresados.Model.Entities;
using Egresados.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services.Interfaces
{
    public interface IPaisServices : IRepositorio<Pais>
    {
        Task<Pais> Save(Pais entidad);
        Task<Pais> Delete(int id);
    }
}
