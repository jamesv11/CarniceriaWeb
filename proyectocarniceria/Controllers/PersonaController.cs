using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Datos;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using proyectocarniceria.Models;

namespace proyectocarniceria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        private readonly PersonaServicio _personaService;

        public PersonaController(CarniceriaContext _context)
        { 
            _personaService = new PersonaServicio(_context);
        }

        // Post: api/Cliente
        [HttpPost]
        public ActionResult<ClienteViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }
        


        private static Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
            {
                Nombre = personaInput.Nombre,
                Apellido = personaInput.Apellido,
                Correo = personaInput.Correo,
                Password = personaInput.Password,
                Identificacion = "",
                Direccion = "",
                Telefono ="",
                Rol = ""
            };              
            return persona;
        }
    }
}