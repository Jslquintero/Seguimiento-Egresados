﻿using AutoMapper;
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
    public class PerfilesController : Controller
    {
        private readonly ILogger<PerfilesController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly IPerfilServices _perfilServices;

        public PerfilesController(ILogger<PerfilesController> logger,
                               IMapper mapper,
                               UserManager<Usuario> userManager,
                               IPerfilServices perfilServices
                          )
        {
            _logger = logger;
            _mapper = mapper;
            _perfilServices = perfilServices;
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