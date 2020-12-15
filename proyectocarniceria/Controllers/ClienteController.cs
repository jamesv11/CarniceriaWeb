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

namespace WebPulsaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServicio _clienteService;
        
        public ClienteController( CarniceriaContext _context)
        {
            _clienteService = new ClienteServicio(_context);
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<ClienteViewModel>> Gets()
        {
            var response = _clienteService.Consultar(); 
            if(response.Error){
                ModelState.AddModelError("Obtener cliente", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            var clientes = response.Clientes.Select(p => new ClienteViewModel(p));
            return Ok(clientes);
        }
        
        // Get:  api/Cliente/correo
        [HttpGet("{correo}")]
        public ActionResult<IEnumerable<ClienteViewModel>> Gets(string correo)
        {
            var response = _clienteService.buscarCliente(correo); 
            if(response.Error){
           
                ModelState.AddModelError("Buscar cliente", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            var cliente = new ClienteViewModel(response.Cliente);
            return Ok(cliente);
        }

        // Post: api/Cliente
        [HttpPost]
        public ActionResult<ClienteViewModel> Post(ClienteInputModel clienteInput)
        {
            Cliente cliente = MapearCliente(clienteInput);
            var response = _clienteService.Guardar(cliente);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar cliente", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            return Ok(response.Cliente);
        }
        // Put: api/Cliente
        [HttpPut]
        public ActionResult<ClienteViewModel> Put(ClienteInputModel clienteInput)
        {
            Cliente cliente = MapearCliente(clienteInput);
            var response = _clienteService.Modificar(cliente);
            if (response.Error)
            {
                ModelState.AddModelError("Modificar Cliente", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            return Ok(response.Cliente);
        }
        private Cliente MapearCliente(ClienteInputModel clienteInput)
        {
            var cliente = new Cliente
            {
                ValorDescuento = clienteInput.ValorDescuento, 
                Persona = clienteInput.Persona           
            };
                            
            return cliente;
        }
        
    }
}