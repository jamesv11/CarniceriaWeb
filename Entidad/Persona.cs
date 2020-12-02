using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Persona
    {     
        [Key]
        public string Correo {get;set;} 
        public string Identificacion { get; set; }
        public string Nombre {get;set;}
        public string Apellido {get;set;}  
        public string Password {get;set;}
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Rol {get;set;}      

    }

    
}