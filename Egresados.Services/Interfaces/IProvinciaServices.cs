using Egresados.Model.Entities;
using Egresados.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services.Interfaces
{
    public interface IProvinciaServices : IRepositorio<Provincia>
    {
        Task<Provincia> Save(Provincia entidad);
        Task<Provincia> Delete(int id);
    }
}
