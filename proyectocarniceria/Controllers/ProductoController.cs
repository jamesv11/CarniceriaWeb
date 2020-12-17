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
using System.IO;

namespace WebPulsaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoServicio _productoServicio;
        private readonly IHubContext<SignalHub> _signalService;
        
        public ProductoController( CarniceriaContext _context, IHubContext<SignalHub> signalService)
        {
            _productoServicio = new ProductoServicio(_context);
            _signalService=signalService;
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
        public async Task<ActionResult<ProductoViewModel>> Post(ProductoInputModel productoInputModel)
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
            var productoNuevo = new ProductoViewModel(response.producto);
            await _signalService.Clients.All.SendAsync("ProductoRegistrado",productoNuevo);
            return Ok(productoNuevo);
        }
        
        // Post: api/Producto
        [HttpPost("Res")]
        public ActionResult<ProductoResViewModel> GuardarRes(ProductoResInputModel productoInputModel)
        {
            ProductoCarne producto = MapearProductoRes(productoInputModel);
            var response = _productoServicio.GuardarCarne(producto);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar productoCarne", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            return Ok(response.producto);
        }
        
        // GET: api/Producto
        [HttpGet]
        public ActionResult<IEnumerable<ProductoViewModel>> Gets()
        {
            var response = _productoServicio.ConsultarTodos(); 
            if(response.Error){
           
                ModelState.AddModelError("Consultar productos", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
            }
            var productos = response.Productos.Select(p => new ProductoViewModel(p));
            return Ok(productos);
        }

        // GET: api/Producto
        [HttpGet("Res")]
        public ActionResult<IEnumerable<ProductoResViewModel>> GetsCarnes()
        {
            var response = _productoServicio.ConsultarTodasRes(); 
            if(response.Error){
           
                ModelState.AddModelError("Consultar productos", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
            }
            var Carnes = response.Productos.Select(p => new ProductoResViewModel(p));
            return Ok(Carnes);
        }

        [HttpPut]
        public ActionResult<IEnumerable<ProductoViewModel>> GuardarRes(List<ProductoViewModel> productoInputModels)
        {
            List<Producto> productos = MapearListaProducto(productoInputModels);
            var response = _productoServicio.UpdateLista(productos);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar productoCarne", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);
            }
            var _productos = response.productos.Select(p => new ProductoViewModel(p));
            return Ok(_productos);
        }
        
        private Producto MapearProducto(ProductoInputModel productoInputModel)
        {
           
            var producto = new Producto{
                NombreProducto = productoInputModel.NombreProducto,
                Cantidad = productoInputModel.Cantidad,
                ValorUnitario = productoInputModel.ValorUnitario,
                Descripcion = productoInputModel.Descripcion,
                Categoria = productoInputModel.Categoria,
                ImagenProducto = productoInputModel.ImagenProducto
            };         
            return producto;
        }

        private List<Producto> MapearListaProducto(List<ProductoViewModel> productoInputModel)
        {
           var lista = new List<Producto>();
           foreach (var item in productoInputModel)
           {
               lista.Add(MapearProductoView(item));
           }
            
            return lista;
        }

        private Producto MapearProductoView(ProductoViewModel productoInputModel)
        {
           
            var producto = new Producto{
                ProductoId = productoInputModel.ProductoId,
                NombreProducto = productoInputModel.NombreProducto,
                Cantidad = productoInputModel.Cantidad,
                ValorUnitario = productoInputModel.ValorUnitario,
                Descripcion = productoInputModel.Descripcion,
                Categoria = productoInputModel.Categoria,
                ImagenProducto = productoInputModel.ImagenProducto
            };         
            return producto;
        }
        

        private ProductoCarne MapearProductoRes(ProductoResInputModel  productoResInputModel)
        {
            var producto = new ProductoCarne
            {
                NombreProducto = productoResInputModel.NombreProducto,
                Cantidad = productoResInputModel.Cantidad,
                ValorUnitario = productoResInputModel.ValorUnitario,
                Descripcion = productoResInputModel.Descripcion,
                Categoria = productoResInputModel.Categoria,
                ImagenProducto  = productoResInputModel.ImagenProducto ,
                CorteRes = productoResInputModel.CorteRes
                
            };
            
            
            return producto;
        }
        
    }
}