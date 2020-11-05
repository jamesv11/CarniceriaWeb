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
using System.IO;

namespace WebPulsaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenProductoController: ControllerBase
    {
        private readonly ImagenProductoServicio _ImagenProductoServicio;
        
        public ImagenProductoController( CarniceriaContext _context)
        {
            _ImagenProductoServicio = new ImagenProductoServicio(_context);
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
        // Post: api/ImagenProducto
        [HttpPost]
        public ActionResult<int> UploadByte()
        {
            var imagenProducto = new ImagenProducto();
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        imagenProducto.Imagen = memoryStream.ToArray();
                    }
                    var response = _ImagenProductoServicio.Guardar(imagenProducto);
                    if (response.Error)
                    {
                        return BadRequest(response.Mensaje);
                    }
                    return Ok(response.ID);                   


                }
                else
                {
                    return BadRequest();
                }
            }
            catch 
            {
                return StatusCode(500, "Internal server error");
            }

          
        }

    }
}