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
    [Authorize]
    public class BolsaTrabajosController : ControllerBase
    {
        private readonly ILogger<BolsaTrabajosController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly IBolsaTrabajoServices _bolsaTrabajoServices;

        public BolsaTrabajosController(ILogger<BolsaTrabajosController> logger,
                               IMapper mapper,
                               UserManager<Usuario> userManager,
                               IBolsaTrabajoServices bolsaTrabajoServices
                          )
        {
            _logger = logger;
            _mapper = mapper;
            _bolsaTrabajoServices = bolsaTrabajoServices;
        }

        /// <summary>
        /// Listado completo de objetos.
        /// </summary>
        [HttpGet("getList")]
        public async Task<ActionResult<List<BolsaTrabajo>>> GetList()
        {
            var result = await _bolsaTrabajoServices.GetListAsync(a=> !a.FechaBaja.HasValue);
            return result;
        }

        /// <summary>
        /// Obtiene la informacion del objeto.
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("getOne/{id}")]
        public async Task<ActionResult<BolsaTrabajo>> GetOne(int? id)
        {
            var result = await _bolsaTrabajoServices.GetOneAync(a => a.Id == id && !a.FechaBaja.HasValue);
            return result;
        }

        /// <summary>
        /// Crea o Edita un nuevo Objeto.
        /// </summary>
        /// <param name="model"></param> 
        [HttpPost("save")]
        public async Task<ActionResult> Save(BolsaTrabajoViewModel model)
        {
            try
            {
                var entidad = _mapper.Map<BolsaTrabajoViewModel, BolsaTrabajo>(model);
                var result = await _bolsaTrabajoServices.Save(entidad);
                if (result.Id > 0)
                    return Ok();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Eliminacion de un Objeto.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                await _bolsaTrabajoServices.Delete(id.Value);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
