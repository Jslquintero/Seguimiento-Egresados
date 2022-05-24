using Egresados.Data;
using Egresados.Model.Entities;
using Egresados.Services.Interfaces;
using Egresados.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Egresados.Services
{
    public class LugarEventoServices : Repositorio<LugarEvento>, ILugarEventoServices
    {
        private readonly ApplicationDbContext _context;      

        public LugarEventoServices(ApplicationDbContext context) : base(context)
        {
            _context = context;       
        }

        public async Task<LugarEvento> Save(LugarEvento entidad)
        {

            if (entidad.Id == 0)
            {
                entidad.FechaAlta = DateTime.Now;
                await InsertAsync(entidad);
            }
            else
            {
                entidad.FechaModificacion = DateTime.Now;
                await UpdateAsync(entidad);
            }
            return entidad;
        }

        public async Task<LugarEvento> Delete(int id)
        {
            var entidad = await GetOneAync(a => a.Id == id);
            await DeleteAsync(entidad);
            return entidad;
        }

    }
}
