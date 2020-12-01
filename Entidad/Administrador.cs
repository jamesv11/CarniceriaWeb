  
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Administrador
    {
        public int AdministradorId { get; set; }


        public Administrador(){this.Persona.Rol = "Administrador";}


        //Relacion con la clase persona

        public Persona Persona { get; set; }
        
      
    }
}