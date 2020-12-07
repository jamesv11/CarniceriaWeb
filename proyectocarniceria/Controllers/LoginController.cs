using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using proyectocarniceria.Models;
using proyectocarniceria.Service;
using Microsoft.Extensions.Options;
using proyectocarniceria.Config;
using Entidad;

namespace proyectocarniceria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        CarniceriaContext _context;
        ClienteServicio _clienteService;
        PersonaServicio _personaServicio;
        JwtService _jwtService;

        public LoginController(CarniceriaContext context, IOptions<AppSetting> appSettings)
        {
            _context = context;
            _clienteService = new ClienteServicio(context);
            _personaServicio = new PersonaServicio(context);
            _jwtService = new JwtService(appSettings);
        }
        
        [HttpPost()]

        public IActionResult Login(LoginInputModel model)
        {
            var user = _clienteService.Validate(model.Correo, model.Password);
            if(user == null)return BadRequest("Correo o contraseña incorrecta");
            var response = _jwtService.GenerateToken(user);
            return Ok(response);   
        }

        // GET: api/Rol/
        [HttpGet ("{correo}")]
        public ActionResult<string> GetRol(string correo){
            var rol = _personaServicio.ObtenerRol(correo);
            if(string.IsNullOrEmpty(rol)){
                return "Rol.cliente";
            }
            return rol;
        }


    }
}