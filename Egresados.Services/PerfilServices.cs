using Egresados.Data;
using Egresados.Data.Repositorio;
using Egresados.Model.Entities;
using Egresados.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Egresados.Services
{
    public class PerfilServices : IPerfilServices
    {
        private readonly IMongoCollection<Perfil> _perfiles;
        private readonly UserManager<Usuario> _userManager;
        public PerfilServices(IDbClient dbClient)
        {
            _perfiles = dbClient.GetPerfilCollection();
        }

        public async Task<List<Perfil>> GetPerfilesAsync()
        {
            var list = await _perfiles.FindAsync(a =>true);
            var result = list.ToList();
            return result;
        }

        public async Task<string> GenerarId(Perfil entidad)
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            var alphanumeric_string =  path.Substring(0, 8);  // Return 8 character string
            
            return alphanumeric_string;
          
        }

        //public Perfil Save(Perfil entidad)
        //{
        //    _perfiles.InsertOne(entidad);
        //    return entidad;
        //}

        public async Task<Perfil> Save(Perfil entidad)
        {
            using (TransactionScope transaccion = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                   
                    if (entidad.Id == "")
                    {
                        var Id = await GenerarId(entidad);
                        entidad.Id = Id;
                        entidad.FechaAlta = DateTime.Now;
                        await _perfiles.InsertOneAsync(entidad);
                    }
                    else
                    {
                        //await ActualizarPedido(entidad);                      
                      
                        entidad.FechaModificacion = DateTime.Now;

                       await _perfiles.ReplaceOneAsync(a => a.Id == entidad.Id, entidad);
                        
                        
                    }

                    transaccion.Complete();
                    return entidad;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<Perfil> GetOne(string id)
        {
            var list = await  _perfiles.Find(a => a.Id == id).ToListAsync();
            var result = list.FirstOrDefault();
            return result;
        }

        public async Task<Perfil> GetOneUsuario(string id)
        {
            //var user = await _userManager.FindByIdAsync(id);
            var list = _perfiles.Find(a => a.UsuarioId == id).FirstOrDefault();
            var result = list;
            return result;
        }
    }
}
