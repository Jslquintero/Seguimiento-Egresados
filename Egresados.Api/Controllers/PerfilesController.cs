using AutoMapper;
using Egresados.Model.Entities;
using Egresados.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class PerfilesController : ControllerBase
    {
        private readonly ILogger<PerfilesController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly IPerfilServices _perfilServices;
        private readonly IFacultadServices _facultadServices;
        private readonly IProvinciaServices _provinciaServices;

        public PerfilesController(ILogger<PerfilesController> logger,
                               IMapper mapper,
                               UserManager<Usuario> userManager,
                               IPerfilServices perfilServices,
                               IFacultadServices facultadServices,
                               IProvinciaServices provinciaServices
                          )
        {
            _logger = logger;
            _mapper = mapper;
            _perfilServices = perfilServices;
            _facultadServices = facultadServices;
            _provinciaServices = provinciaServices;
        }

        /// <summary>
        /// Listado completo de objetos.
        /// </summary>
        [HttpGet("getList")]
        //public async IActionResult GetPerfil()
        //{
        //    return Ok(_perfilServices.GetPerfilesAsync());
        //}

        public async Task<ActionResult<List<Perfil>>> GetList()
        {
            var result = await _perfilServices.GetPerfilesAsync();
            return result;
        }

        /// <summary>
        /// Obtiene la informacion del objeto.
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("getOne/{id}")]
        public async Task<ActionResult<Perfil>> GetOne(string id)
        { 
            var result = await _perfilServices.GetOne(id);
           
            return result;
        }

        /// <summary>
        /// Obtiene la informacion del objeto.
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("getOneUsuario/{id}")]
        public async Task<ActionResult<Perfil>> GetOneUsuario(string id)
        {
            var result = await _perfilServices.GetOneUsuario(id);

            return result;
        }

        // <summary>
        /// Crea o Edita un nuevo Objeto.
        /// </summary>
        /// <param name="model"></param> 
        [HttpPost("save")]
        public async Task<ActionResult> Save(PerfilViewModel model)
        {
            try
            {              
                var entidad = _mapper.Map<PerfilViewModel, Perfil>(model);
                var result = await _perfilServices.Save(entidad);
                if (result.Id != null)
                    return Ok();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
