using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
namespace Logica
{
    public class PersonaServicio
    {
        private readonly CarniceriaContext _context;

        public PersonaServicio(CarniceriaContext context)
        { 
            _context = context;
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                var verificarPersona = _context.Personas.Find(persona.Correo);
                if(verificarPersona != null)
                {
                    return new GuardarPersonaResponse("Error el cliente se encuentra registrado ");
                }
                    _context.Personas.Add(persona);
                    _context.SaveChanges();
                    return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public string ObtenerRol(string Correo){
            var persona = _context.Personas.Find(Correo);
            return persona.Rol;
        }
    }
    public class GuardarPersonaResponse
    {
        public GuardarPersonaResponse(Persona persona )
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
}