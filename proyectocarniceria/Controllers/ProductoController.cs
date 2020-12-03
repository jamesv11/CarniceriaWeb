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
    public class ProductoController : ControllerBase
    {
        private readonly ProductoServicio _productoServicio;
        private readonly ImagenProductoServicio _ImagenServicio;
        
        public ProductoController( CarniceriaContext _context)
        {
            _productoServicio = new ProductoServicio(_context);
            _ImagenServicio = new ImagenProductoServicio(_context);
        }

        /*
        // GET: api/Persona
        [HttpGet]
        public ActionResult<IEnumerable<PersonaViewModel>> Gets()
        {
            var response = _personaService.ConsultarTodos(); 
            if(response.Error){
           
                return BadRequest(response.Mensaje);
            }
            var personas = response.Personas.Select(p => new PersonaViewModel(p));
            return Ok(personas);
        }
        */
        // Post: api/Producto
        [HttpPost]
        public ActionResult<ProductoViewModel> Post(ProductoInputModel productoInputModel)
        {
            Producto producto = MapearProducto(productoInputModel);
            var response = _productoServicio.Guardar(producto);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar producto", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            return Ok(response.producto);
        }
        private Producto MapearProducto(ProductoInputModel productoInputModel)
        {
            var producto = new Producto
            {
                
            };
            
            
            return producto;
        }
    }
}