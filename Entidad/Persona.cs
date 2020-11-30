using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Persona
    {
        public int PersonaId {get;set;}      
        public string Identificacion { get; set; }
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        public string Correo {get;set;}
        public string Password {get;set;}
        public string Rol {get;set;}


        //Relacion con la entidad Administrador

        public int AdministradorId { get; set; }

        public Administrador Administrador { get; set; }

        //Relacion con la entidad Cliente

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        //Relacion con la entidad Domiciliario

        public int DomiciliarioId {get; set; }
        public Domiciliario Domiciliario { get; set; }

    }

    
}