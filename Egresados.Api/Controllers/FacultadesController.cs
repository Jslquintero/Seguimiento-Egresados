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
    public class FacultadesController : ControllerBase
    {
        private readonly ILogger<FacultadesController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly IFacultadServices _facultadeServices;

        public FacultadesController(ILogger<FacultadesController> logger,
                               IMapper mapper,
                               UserManager<Usuario> userManager,
                               IFacultadServices facultadeServices
                          )
        {
            _logger = logger;
            _mapper = mapper;
            _facultadeServices = facultadeServices;
        }

        /// <summary>
        /// Obtiene listado para los select.
        /// </summary>     
        [HttpGet("selectList")]
        public async Task<ActionResult<List<Facultad>>> SelectList()
        {
            var result = await _facultadeServices.GetListAsync();
            return result;
        }
    }
}
