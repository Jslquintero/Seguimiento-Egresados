using Egresados.Model.Entities;
using Egresados.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services.Interfaces
{
    public interface ICentroEducativoServices : IRepositorio<CentroEducativo>
    {
        Task<CentroEducativo> Save(CentroEducativo entidad);
        Task<CentroEducativo> Delete(int id);
    }
}
