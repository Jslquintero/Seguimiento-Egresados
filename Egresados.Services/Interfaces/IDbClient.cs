using Egresados.Model.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services.Interfaces
{
    public interface IDbClient
    {
        IMongoCollection<Perfil> GetPerfilCollection();
    }
}
