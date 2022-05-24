using AutoMapper;
using Egresados.Api.Models;
using Egresados.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egresados.Api.Utils
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Perfil, PerfilViewModel>().ReverseMap();
            CreateMap<Evento, EventoViewModel>().ReverseMap();
            CreateMap<BolsaTrabajo, BolsaTrabajoViewModel>().ReverseMap();

        }

    }
}
