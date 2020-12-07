using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Entidad;

namespace proyectocarniceria.Models
{
    public class LoginInputModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; } 
        public string Correo { get; set; }  
        public string Password { get; set; } 
        public string Rol { get; set; }
    }

    public class LoginViewModel
    {   
      public string Nombre { get; set; }
      public string Apellido { get; set; } 
      public string Correo { get; set; }   
      public string Rol { get; set; }

       [JsonIgnore]
       public string Password { get; set; }
       public string Token { get; set; }

    
    }
}
    