using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
   
    public class DomiciliarioServicio
    {
        private readonly CarniceriaContext _context;

        public DomiciliarioServicio(CarniceriaContext context)
        {
            _context = context;
        }

        public GuardarDomiciliarioResponse Guardar(Domiciliario domiciliario)
        {
            try
            {
                var verificarDomiciliario = _context.Domiciliarios.Find(domiciliario.Persona.Correo);
                if(verificarDomiciliario != null)
                {
                    return new GuardarDomiciliarioResponse("Error el cliente se encuentra registrado ");
                }
                domiciliario.Persona.Rol = "Rol.Domiciliario";
                _context.Domiciliarios.Add(domiciliario);
                _context.SaveChanges();
                return new GuardarDomiciliarioResponse(domiciliario);
            }
            catch (Exception e)
            {
                return new GuardarDomiciliarioResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

           public ConsultarDomiciliarioResponse ConsultarTodos()
        {
            try
            {
                var domiciliarios = _context.Domiciliarios.Include(p => p.Persona).ToList();
                return new ConsultarDomiciliarioResponse(domiciliarios);

            }
            catch (Exception e)
            {
                return new ConsultarDomiciliarioResponse($"error de aplicacion: {e.Message}");
            }

        }
        public BuscarDomiciliarioResponse buscarCliente(string correo){
            try
            {
                var domiciliario = _context.Domiciliarios.Include(p => p.Persona).Where(p => p.Persona.Correo ==  correo).FirstOrDefault();
                return new BuscarDomiciliarioResponse(domiciliario);
            }
            catch (Exception e)
            {
                
                return new BuscarDomiciliarioResponse($"Error de aplicacion: {e.Message}");
            }
        }
    }

    public class GuardarDomiciliarioResponse
    {
        public GuardarDomiciliarioResponse(Domiciliario domiciliario )
        {
            Error = false;
            Domiciliario = domiciliario;
        }
        public GuardarDomiciliarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Domiciliario Domiciliario { get; set; }
    }
    public class ConsultarDomiciliarioResponse
    {
        public ConsultarDomiciliarioResponse(List<Domiciliario> domiciliarios)
        {
            Error = false;
            Domiciliarios = domiciliarios;
        }
        public ConsultarDomiciliarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Domiciliario> Domiciliarios { get; set; }
    }
    public class BuscarDomiciliarioResponse
    {
        public BuscarDomiciliarioResponse(Domiciliario domiciliario)
        {
            Error = false;
            Domiciliario = domiciliario;
        }
        public BuscarDomiciliarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Domiciliario Domiciliario { get; set; }
    }
}