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

namespace proyectocarniceria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly PedidoServicio pedidoServicio;

        public PedidoController(CarniceriaContext _context)
        { 
            pedidoServicio = new PedidoServicio(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PedidoViewModel>> Gets()
        {
            var response = pedidoServicio.ConsultarTodos(); 
            if(response.Error){
                ModelState.AddModelError("Obtener pedidos", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            var pedidos = response.Pedidos.Select(d => new PedidoViewModel(d));
            return Ok(pedidos);
        }
        [HttpPut]
        public ActionResult<PedidoViewModel> Put(PedidoInputModel pedidoInput)
        {
            Pedido pedido = MapearPedido(pedidoInput);
            var response = pedidoServicio.Modificar(pedido);
            if (response.Error)
            {
                ModelState.AddModelError("Modificar pedido", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            return Ok(response.Pedido);
        }
        private Pedido MapearPedido(PedidoInputModel pedidoInput)
        {
            var pedido = new Pedido
            {
                PedidoId = pedidoInput.PedidoId,
                Factura = pedidoInput.Factura,
                Estado = pedidoInput.Estado,
                CedulaDomicilario = pedidoInput.CedulaDomicilario          
            };
                            
            return pedido;
        }


        
    }
}