﻿using Egresados.Data.Repositorio;
using Egresados.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Services.Interfaces
{
    public interface IPerfilServices
    {
        Task<List<Perfil>> GetPerfilesAsync();
        Task<Perfil> Save(Perfil perfil);
        Task<Perfil> Delete(string id);
    }
}
