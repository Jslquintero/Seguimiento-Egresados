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
    public class EventosController : ControllerBase
    {
        private readonly ILogger<EventosController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly IEventoServices _eventoServices;

        public EventosController(ILogger<EventosController> logger,
                               IMapper mapper,
                               UserManager<Usuario> userManager,
                               IEventoServices eventoServices
                          )
        {
            _logger = logger;
            _mapper = mapper;
            _eventoServices = eventoServices;
        }

        /// <summary>
        /// Listado completo de objetos.
        /// </summary>
        [HttpGet("getList")]
        public async Task<ActionResult<List<Evento>>> GetList()
        {
            string[] _include = { nameof(Evento.LugarEvento), nameof(Facultad)};
            var result = await _eventoServices.GetListAsync(a=> !a.FechaBaja.HasValue, _include);
            return result;
        }

        /// <summary>
        /// Obtiene la informacion del objeto.
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("getOne/{id}")]
        public async Task<ActionResult<Evento>> GetOne(int? id)
        {
            string[] _include = { nameof(Evento.LugarEvento), nameof(Facultad) };
            var result = await _eventoServices.GetOneAync(a => a.Id == id && !a.FechaBaja.HasValue, _include);
            return result;
        }

        /// <summary>
        /// Crea o Edita un nuevo Objeto.
        /// </summary>
        /// <param name="model"></param> 
        [HttpPost("save")]
        public async Task<ActionResult> Save(EventoViewModel model)
        {
            try
            {
                var entidad = _mapper.Map<EventoViewModel, Evento>(model);
                var result = await _eventoServices.Save(entidad);
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
                await _eventoServices.Delete(id.Value);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene listado para los select.
        /// </summary>     
        [HttpGet("selectList")]
        public async Task<ActionResult<List<Evento>>> SelectList()
        {
            var result = await _eventoServices.GetListAsync();
            return result;
        }
    }
}
