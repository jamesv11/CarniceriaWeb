using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Persona
    {
        public int PersonaID {get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        public string Correo {get;set;}
        public string Password {get;set;}

    }
}