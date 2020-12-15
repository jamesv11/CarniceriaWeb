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
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;
        
        public FacturaController( CarniceriaContext _context)
        {
            _facturaService = new FacturaService(_context);
        }

        

    
        // Post: api/Factura
        [HttpPost]
        public ActionResult<FacturaViewModel> Post(FacturaInputModel facturaInputModel)
        {
            Factura nuevaFactura= MapearFactura(facturaInputModel);
            var response = _facturaService.GuardarFactura(nuevaFactura);
            if (response.error)
            {
                ModelState.AddModelError("Guardar factura", response.respuesta);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            return Ok(response.factura);
        }

        // GET: api/Factura
        [HttpGet]
        public ActionResult<IEnumerable<ProductoViewModel>> Gets()
        {
            var response = _facturaService.ConsultarTodos(); 
             if(response.Error){
           
                 ModelState.AddModelError("Consultar Factura", response.Respuesta);
                 var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                 };
             }
            var facturas = response.Facturas.Select(p => new FacturaViewModel(p));
            return Ok(facturas);
        }

        private Factura MapearFactura(FacturaInputModel _factura)
        {
            var factura = new Factura();
            factura.DetallesFacturas = _factura.DetallesFacturas; 
            factura.Correo = _factura.Correo;                           
            return factura;
        }
        
    }
}