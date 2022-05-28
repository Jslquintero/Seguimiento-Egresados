using Egresados.Api.Models;
using Egresados.Model.Entities;
using Egresados.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Egresados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Rol> _rolManager;

        public UsuariosController(ILogger<UsuariosController> logger,
                                 IConfiguration configuration,
                                 SignInManager<Usuario> signInManager,
                                 UserManager<Usuario> userManager,
                                 RoleManager<Rol> rolManager)
        {
            _logger = logger;
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _rolManager = rolManager;
        }


        /// <summary>
        /// Ingreso de usuario al sistema.
        /// </summary>
        /// <param name="model"></param> 
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioViewModel>> Login(LoginViewModel model)
        {
            try
            {
                // Tu código para validar que el usuario ingresado es válido
                var result = await _signInManager.PasswordSignInAsync(model.Cedula, model.Password, false, lockoutOnFailure: false);

                if (!result.Succeeded)
                    return Unauthorized();

                var user = await _userManager.FindByNameAsync(model.Cedula);
                var roles = await _userManager.GetRolesAsync(user);
                user.Roles = roles;

                var token = GenerarTokenJwt(user);


                return token;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Usuario cierra session.
        /// </summary>  
        [AllowAnonymous]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        /// <summary>
        /// Registrar de Usuarios.
        /// </summary>
        /// <param name="model"></param> 
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegistrarViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                { 
                    var user = new Usuario
                    {
                        Name = model.Name,
                        LastName= model.LastName,
                        UserName = model.Cedula, //UserName es el campo que almacena la cedula
                        Email = model.Email,
                        Roles = model.Roles
                    
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        foreach (var rol in user.Roles)
                        {
                            await _userManager.AddToRoleAsync(user, rol);
                        }

                        await _userManager.SetLockoutEnabledAsync(user, false);
  
                        return Ok();
                    }
                    var errorString = "";
                    foreach (var error in result.Errors)
                    {
                        errorString += error.Description + "\n";
                    }
                    if (errorString.Length > 0)
                        return BadRequest(errorString);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
       
        }

        /// <summary>
        /// Editar de Usuarios.
        /// </summary>
        /// <param name="model"></param> 
        [HttpPost("editar")]
        public async Task<IActionResult> Editar(UsuarioViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByIdAsync(model.Id);
                    user.Name = model.Name;
                    user.LastName = model.LastName;
                    user.Roles = model.Roles;
                


                    //Removemos todos los roles
                    var roles = _rolManager.Roles.ToList();
                    foreach (var item in roles)
                    {
                        await _userManager.RemoveFromRoleAsync(user, item.Name);
                    }

                    //Agregamos los seleccionados
                    foreach (var item in model.Roles)
                    {
                        await _userManager.AddToRoleAsync(user, item);
                    }

                    await _userManager.UpdateAsync(user);
                    return Ok();
                }

            }
          
             catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();

        }


        private UsuarioViewModel GenerarTokenJwt(Usuario usuario)
        {

            // Leemos el secret_key desde nuestro appseting
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Creamos los claims (pertenencias, características) del usuario
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                new Claim(ClaimTypes.Name, usuario.UserName)
            };

            foreach (var item in usuario.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }


            var claim = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claim,
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddHours(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);


            var token = new UsuarioViewModel()
            {
                Id = usuario.Id,
                Token = tokenHandler.WriteToken(createdToken),
                FechaExpiraToken = tokenDescriptor.Expires,
                UserName = usuario.UserName,
                Name = usuario.Name,
                LastName = usuario.LastName,
                Cedula = usuario.UserName,
                Roles = usuario.Roles,
               
                
            };
            return token;
        }

        /// <summary>
        /// Listado de usuarios
        /// </summary>  
        [Authorize(Roles = "Administrador,Administrativo")]
        [HttpGet("getList")]
        public async Task<List<Usuario>> GetList()
        {

            var result = _userManager.Users.ToList();
            foreach (var item in result)
            {
                item.Roles = await _userManager.GetRolesAsync(item);
            }
            return result;

        }

        /// <summary>
        /// Listado de roles
        /// </summary>  
        [Authorize(Roles = "Administrador,Administrativo")]
        [HttpGet("getListRoles")]
        public async Task<List<Rol>> GetListRoles()
        {

            var result =  _rolManager.Roles.ToList();
            
            return result;

        }

        /// <summary>
        /// Listado de roles
        /// </summary>  
        [Authorize(Roles = "Administrador,Administrativo")]
        [HttpGet("getOne/{id}")]
        public async Task<Usuario> GetOne(string id)
        {

            var result = await _userManager.FindByIdAsync(id);
            result.Roles = await _userManager.GetRolesAsync(result);
            return result ;
            
        }



    }
}
