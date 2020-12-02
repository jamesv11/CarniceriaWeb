using Entidad;

namespace proyectocarniceria.Models
{
    public class PersonaInputModel
    {
        public string Correo {get;set;} 
        public string Nombre {get;set;}
        public string Apellido {get;set;}  
        public string Password {get;set;}
        public string Rol { get; set; }
 
    }
    public class PersonaViewModel : PersonaInputModel
    {

        public PersonaViewModel(Persona persona){
            Correo =  persona.Correo;
            Nombre = persona.Nombre;
            Apellido = persona.Apellido;
            Password = persona.Password;
            Direccion = persona.Direccion;
            Telefono = persona.Telefono;
            Rol = persona.Rol;
        }

     
        public string Direccion { get; set; }
        public string Telefono { get; set; }
      

        
    }
}