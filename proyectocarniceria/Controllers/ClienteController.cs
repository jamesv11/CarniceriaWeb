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
           
                return BadRequest(response.Mensaje);
            }
            var clientes = response.Clientes.Select(p => new ClienteViewModel(p));
            return Ok(clientes);
        }
        
        // Get:  api/Cliente/personaId
        [HttpGet("{personaID}")]
        public ActionResult<IEnumerable<ClienteViewModel>> Gets(int personaID)
        {
            var response = _clienteService.buscarCliente(personaID); 
            if(response.Error){
           
                return BadRequest(response.Mensaje);
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
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Cliente);
        }
        private Cliente MapearCliente(ClienteInputModel clienteInput)
        {
            var cliente = new Cliente
            {
                ValorDescuento = 0, 
                Persona = clienteInput.Persona           
            };
              
                  
            return cliente;
        }
        
    }
}