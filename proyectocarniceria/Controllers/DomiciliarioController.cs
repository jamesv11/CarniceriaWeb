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
using proyectocarniceria.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace WebPulsaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomiciliarioController: ControllerBase
    {
        private readonly DomiciliarioServicio _domiciliarioService;
        private readonly IHubContext<SignalHub> _signalService;
        
        public DomiciliarioController( CarniceriaContext _context,IHubContext<SignalHub> signalService)
        {
            _domiciliarioService = new DomiciliarioServicio(_context);
            _signalService=signalService;
        }

        
        // GET: api/Domiciliario
        [HttpGet]
        public ActionResult<IEnumerable<DomiciliarioViewModel>> Gets()
        {
            var response = _domiciliarioService.ConsultarTodos(); 
            if(response.Error){
                ModelState.AddModelError("Obtener domiciliario", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            var domiciliarios = response.Domiciliarios.Select(d => new DomiciliarioViewModel(d));
            return Ok(domiciliarios);
        }
        
        // Post: api/Persona
        [HttpPost]
        public async Task<ActionResult<DomiciliarioViewModel>> Post(DomiciliarioInputModel domiciliarioInput)
        {
            Domiciliario domiciliario = MapearDomiciliario(domiciliarioInput);
            var response = _domiciliarioService.Guardar(domiciliario);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar Domiciliario", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            var domiciliarioNuevo = new DomiciliarioViewModel(response.Domiciliario);
            await _signalService.Clients.All.SendAsync("DomiciliarioRegistrado",domiciliarioNuevo);
            return Ok(domiciliarioNuevo);
        }
        private Domiciliario MapearDomiciliario(DomiciliarioInputModel domiciliarioInput)
        {
            var domiciliario = new Domiciliario
            {
                Persona = domiciliarioInput.Persona
            };
            return domiciliario;
        }
    }
}