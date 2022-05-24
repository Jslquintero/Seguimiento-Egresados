using Egresados.Model.Entities;
using Egresados.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Perfil> _perfil;
        public DbClient(IOptions<EgresadosConfig> egresadosConfig)
        {
            var client = new MongoClient(egresadosConfig.Value.Connection_String);
            var database = client.GetDatabase(egresadosConfig.Value.Database_Name);
            _perfil = database.GetCollection<Perfil>(egresadosConfig.Value.Egresados_Collection_Name);
        }

        public IMongoCollection<Perfil> GetPerfilCollection() => _perfil;


    }
}
