using AutoMapper;
using Egresados.Api.Models;
using Egresados.Model.Entities;
using Egresados.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egresados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LugarEventosController : ControllerBase
    {
        private readonly ILogger<LugarEventosController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILugarEventoServices _lugarEventoServices;

        public LugarEventosController(ILogger<LugarEventosController> logger,
                               IMapper mapper,
                               UserManager<Usuario> userManager,
                               ILugarEventoServices lugarEventoServices
                          )
        {
            _logger = logger;
            _mapper = mapper;
            _lugarEventoServices = lugarEventoServices;
        }

        /// <summary>
        /// Obtiene listado para los select.
        /// </summary>     
        [HttpGet("selectList")]
        public async Task<ActionResult<List<LugarEvento>>> SelectList()
        {
            var result = await _lugarEventoServices.GetListAsync();
            return result;
        }
    }
}
